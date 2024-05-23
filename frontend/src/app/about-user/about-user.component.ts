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
  profileForm!: FormGroup

  constructor( ){
    this.profileForm = new FormGroup({
      name: new FormControl('', Validators.required),
      lastname: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      gender: new FormControl(true),
      isSmoke:new FormControl(true),
      hasPet:new FormControl(false),
      communicationLevel: new FormControl(5),
      pureLevel: new FormControl(5),
      riseTime: new FormControl('', Validators.required),
      sleepTime: new FormControl('', Validators.required),
      timeSpentAtHome: new FormControl('', Validators.required),
      partyFrequency: new FormControl('', Validators.required),
    })
  }
  saveAndContinue(){
    this.profileForm.value.gender = this.gender
    this.profileForm.value.isSmoke = this.isSmoke
    this.profileForm.value.hasPet = this.hasPet

    if (this.profileForm.invalid || this.profileForm.disabled){
      this.profileForm.markAllAsTouched()
      return
    }
    console.log(this.profileForm.value)
  }

  gender:boolean = true;
  public male(){
    document.getElementById('male')!.classList.remove('opacity-40');
    document.getElementById('female')!.classList.add('opacity-40');
    this.gender = true
  }
  public female(){
    document.getElementById('male')!.classList.add('opacity-40');
    document.getElementById('female')!.classList.remove('opacity-40');
    this.gender = false
  }
  isSmoke:boolean = true;
  public smoke(){
    document.getElementById('smoke')!.classList.remove('opacity-40');
    document.getElementById('noSmoke')!.classList.add('opacity-40');
    this.isSmoke = true
  }
  public noSmoke(){
    document.getElementById('smoke')!.classList.add('opacity-40');
    document.getElementById('noSmoke')!.classList.remove('opacity-40');
    this.isSmoke = false
  }
  hasPet:boolean = false;
  public pet(){
    document.getElementById('pet')!.classList.remove('opacity-40');
    document.getElementById('noPet')!.classList.add('opacity-40');
    this.hasPet = true
  }
  public noPet(){
    document.getElementById('pet')!.classList.add('opacity-40');
    document.getElementById('noPet')!.classList.remove('opacity-40');
    this.hasPet = false
  }
  buttonText:string = "Сохранить и продолжить";
}
