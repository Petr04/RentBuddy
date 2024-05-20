import { Component } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';
import { BaseInputComponent } from '../components/base-input/base-input.component';
import { BirthdaySelectComponent } from '../components/birthday-select/birthday-select.component';
import { BiSelectComponent } from '../components/bi-select/bi-select.component';
import { RangeInputComponent } from '../components/range-input/range-input.component';
import { TimeSelectComponent } from '../components/time-select/time-select.component';
import { RadioSelectComponent } from '../components/radio-select/radio-select.component';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';


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
    name: new FormControl(),
    lastname: new FormControl(),
    birthDate: new FormControl(),
    gender: new FormControl(),
    isSmoke:new FormControl(),
    hasPet:new FormControl(),
    communicationLevel: new FormControl(),
    pureLevel: new FormControl(),
    riseTime: new FormControl(),
    sleepTime: new FormControl(),
    timeSpentAtHome: new FormControl()
  })

  }
}
