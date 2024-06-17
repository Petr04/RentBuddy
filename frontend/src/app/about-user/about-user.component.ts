import { Component, OnInit } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule, DatePipe } from '@angular/common';
import { BaseInputComponent } from '../components/base-input/base-input.component';
import { BirthdaySelectComponent } from '../components/birthday-select/birthday-select.component';
import { BiSelectComponent } from '../components/bi-select/bi-select.component';
import { RangeInputComponent } from '../components/range-input/range-input.component';
import { TimeSelectComponent } from '../components/time-select/time-select.component';
import { RadioSelectComponent } from '../components/radio-select/radio-select.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PostService } from '../services/post.service';
import { RouterLink } from '@angular/router';
import { Apartment, UserProfile } from '../interfaces/interface';
import { AuthService } from '../services/auth.service';
import { Observable, map } from 'rxjs';


@Component({
  selector: 'app-about-user',
  standalone: true,
  imports: [RouterLink ,NextBtnComponent, CommonModule,
  BaseInputComponent, BirthdaySelectComponent, BiSelectComponent,
  RangeInputComponent, TimeSelectComponent, RadioSelectComponent, ReactiveFormsModule ],
  providers: [DatePipe],
  templateUrl: './about-user.component.html',
  styleUrl: './about-user.component.css'
})
export class AboutUserComponent implements OnInit {
  profileSavedInfo!: UserProfile
  profileForm!: FormGroup
  hostApartment$?: Observable<Apartment[]>
  gender:boolean = false;
  isSmoke:boolean = false;
  hasPet:boolean = false;
  buttonText:string = "Сохранить и продолжить";
  file:any;

  constructor(private postService: PostService, private datePipe:DatePipe, private auth: AuthService){
    this.profileForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastname: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      gender: new FormControl(''),
      isSmoke:new FormControl(''),
      hasPet:new FormControl(''),
      communicationLevel: new FormControl(5),
      pureLevel: new FormControl(5),
      riseTime: new FormControl('', Validators.required),
      sleepTime: new FormControl('', Validators.required),
      timeSpentAtHome: new FormControl(''),
      partyFrequency: new FormControl('', Validators.required),
      aboutMe: new FormControl('', Validators.required),
      image: new FormControl('')
    })
  }

  ngOnInit(): void {
    this.postService.getUserById().subscribe(res => {
      this.profileSavedInfo = res;
      this.isSmoke = res.isSmoke
      this.hasPet = res.hasPet
      this.gender = Boolean(res.gender)

      this.profileForm.patchValue({
        id: res.id,
        name: res.name,
        lastname: res.lastname,
        birthDate: this.datePipe.transform(res.birthDate, 'yyyy-MM-dd'),
        communicationLevel: +res.communicationLevel,
        pureLevel: +res.pureLevel,
        riseTime: this.datePipe.transform(res.riseTime, 'HH:mm'),
        sleepTime: this.datePipe.transform(res.sleepTime, 'HH:mm'),
        timeSpentAtHome: +res.timeSpentAtHome,
        aboutMe: res.aboutMe
      });
      this.postService.getHostsApartment().subscribe()
      this.hostApartment$ = this.postService?.getHostsApartment().pipe(
        map((data: any)=> data?.hostsApartments )
      )
      // this.postService.getApartmentById("2712b130-f61f-49a6-bd7f-d8dd4497f352").subscribe(r=> console.log(r))
    });


  }

  logout(){
    this.auth.logout()
  }


  uploadImage(event:any){
    this.file = event.target.files[0];
    console.log(this.file);
  }

  saveAndContinue(){
    // const formData = new FormData();
    // formData.append("image", this.file, this.file.name);
    // this.profileForm.patchValue({
    //   image: formData
    // })

    this.profileForm.value.id = this.postService.getUserId()
    this.profileForm.value.gender = this.gender
    this.profileForm.value.isSmoke = this.isSmoke
    this.profileForm.value.hasPet = this.hasPet
    this.profileForm.value.timeSpentAtHome = +this.profileForm.value.timeSpentAtHome
    this.postService.postUser(this.profileForm.value).subscribe()
  }

  public male(){
    this.gender = true
  }
  public female(){
    this.gender = false
  }

  public smoke(){
    this.isSmoke = true
  }
  public noSmoke(){
    this.isSmoke = false
  }

  public pet(){
    this.hasPet = true
  }
  public noPet(){
    this.hasPet = false
  }

}
