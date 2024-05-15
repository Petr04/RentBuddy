import {Directive} from '@angular/core';
import { ValidationErrors } from '@angular/forms';
import { customValidator } from '../custom-validator/custom-validator.component';

@Directive({
  selector: '[appPasswordStrenghtValidator]',
  standalone: true
})
export class PasswordStrenghtValidatorDirective {

  constructor(){

  }

  public validate(control: AbortController): ValidationErrors |null {
    return customValidator(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/)
  }

}
