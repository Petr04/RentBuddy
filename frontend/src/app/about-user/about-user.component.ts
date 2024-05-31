import { Component } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';
import { BaseInputComponent } from '../components/base-input/base-input.component';
import { BirthdaySelectComponent } from '../components/birthday-select/birthday-select.component';
import { BiSelectComponent } from '../components/bi-select/bi-select.component';
import { RangeInputComponent } from '../components/range-input/range-input.component';
import { TimeSelectComponent } from '../components/time-select/time-select.component';
import { RadioSelectComponent } from '../components/radio-select/radio-select.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PostService } from '../services/post.service';


@Component({
  selector: 'app-about-user',
  standalone: true,
  imports: [NextBtnComponent, CommonModule,
  BaseInputComponent, BirthdaySelectComponent, BiSelectComponent,
  RangeInputComponent, TimeSelectComponent, RadioSelectComponent, ReactiveFormsModule ],
  templateUrl: './about-user.component.html',
  styleUrl: './about-user.component.css'
})
export class AboutUserComponent {
  buttonText:string = "Сохранить и продолжить";
  profileForm!: FormGroup

  constructor(private postService: PostService){
    this.profileForm = new FormGroup({
      id: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      lastname: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      gender: new FormControl(1),
      isSmoke:new FormControl(true),
      hasPet:new FormControl(false),
      communicationLevel: new FormControl(5),
      pureLevel: new FormControl(5),
      riseTime: new FormControl('', Validators.required),
      sleepTime: new FormControl('', Validators.required),
      timeSpentAtHome: new FormControl('', Validators.required),
      partyFrequency: new FormControl('', Validators.required),
      description: new FormControl("", Validators.required)
    })
  }
  saveAndContinue(){
    this.profileForm.value.id = localStorage.getItem('userId')
    this.profileForm.value.gender = 1
    this.profileForm.value.isSmoke = this.isSmoke
    this.profileForm.value.hasPet = this.hasPet

    // if (this.profileForm.invalid || this.profileForm.disabled){
    //   this.profileForm.markAllAsTouched()
    //   return
    // }
    this.postService.getPosts().subscribe(res => console.log(res))

  }

  gender:boolean = true;
  public male(){
    this.gender = true
  }
  public female(){
    this.gender = false
  }

  isSmoke:boolean = true;
  public smoke(){
    this.isSmoke = true
  }
  public noSmoke(){
    this.isSmoke = false
  }

  hasPet:boolean = true;
  public pet(){
    this.hasPet = true
  }
  public noPet(){
    this.hasPet = false
  }

}
