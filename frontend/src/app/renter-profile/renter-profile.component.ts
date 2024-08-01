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
  selector: 'app-renter-profile',
  standalone: true,
  imports: [RouterLink ,NextBtnComponent, CommonModule,
  BaseInputComponent, BirthdaySelectComponent, BiSelectComponent,
  RangeInputComponent, TimeSelectComponent, RadioSelectComponent, ReactiveFormsModule ],
  providers: [DatePipe],
  templateUrl: './renter-profile.component.html',
  styleUrl: './renter-profile.component.css'
})
export class RenterProfileComponent implements OnInit {
  public profileSavedInfo!: UserProfile
  public profileForm!: FormGroup
  public gender:boolean = false;
  public isSmoke:boolean = false;
  public hasPet:boolean = false;
  public buttonText:string = "Сохранить и продолжить";
  public file:any;

  constructor(private readonly postService: PostService, private readonly datePipe:DatePipe, private readonly auth: AuthService) {
    this.profileForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastname: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      telegramUsername: new FormControl('', Validators.required),
      gender: new FormControl(''),
      isSmoke:new FormControl(''),
      hasPet:new FormControl(''),
      communicationLevel: new FormControl(5),
      pureLevel: new FormControl(5),
      riseTime: new FormControl('', Validators.required),
      sleepTime: new FormControl('', Validators.required),
      timeSpentAtHome: new FormControl('4'),
      partyFrequency: new FormControl('раз в неделю', Validators.required),
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
        telegramUsername: res.telegramUsername,
        communicationLevel: +res.communicationLevel,
        pureLevel: +res.pureLevel,
        riseTime: this.datePipe.transform(res.riseTime, 'HH:mm'),
        sleepTime: this.datePipe.transform(res.sleepTime, 'HH:mm'),
        timeSpentAtHome: String(res.timeSpentAtHome),
        partyFrequency: String(res.partyFrequency),
        aboutMe: res.aboutMe
      });
    });
  }

  public logout(){
    this.auth.logout()
  }

  public uploadImage(event:any){
    this.file = event.target.files[0];
    console.log(this.file);
  }

  public saveAndContinue(){
    this.profileForm.disable
    this.profileForm.value.id = this.postService.getUserId()
    this.profileForm.value.gender = this.gender
    this.profileForm.value.isSmoke = this.isSmoke
    this.profileForm.value.hasPet = this.hasPet
    this.profileForm.value.timeSpentAtHome = +this.profileForm.value.timeSpentAtHome
    this.postService.postUser(this.profileForm.value).subscribe()
    const formData = new FormData();
    formData.append("file", this.file, this.file.name);
    this.postService.uploadAvatar(formData).subscribe(response => {
      console.log(response);
    });
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
