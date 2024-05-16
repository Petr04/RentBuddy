import { Component } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import { conformPassword, customValidator } from '../custom-validator/custom-validator.component';
import { RouterLink } from '@angular/router';
import { PasswordStrengthDirective } from '../directives/password-strenght-validator.directive';

@Component({
  selector: 'app-registration-page',
  standalone: true,
  imports: [NextBtnComponent, ReactiveFormsModule, FormsModule, RouterLink, PasswordStrengthDirective],
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {

  public registrationForm!: FormGroup


  constructor(){
    this.registrationForm = new FormGroup(
      {
        userEmail: new FormControl('', [Validators.required, Validators.email]),
        userPassword: new FormControl(''),
        userPassword2: new FormControl('')
      },
      conformPassword
    );
  }

  public onSubmit(){
    if (this.registrationForm.invalid){
      this.registrationForm.markAllAsTouched()
      return
    }
    console.log(this.registrationForm.value)
  }

}
