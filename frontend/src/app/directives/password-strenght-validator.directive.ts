import {Directive} from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';
import { customValidator } from '../custom-validator/custom-validator.component';

@Directive({
  selector: '[passwordStrength]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: PasswordStrengthDirective,
    multi: true
  }],
  standalone: true
})
export class PasswordStrengthDirective implements Validator {

  public validate(control: AbstractControl): ValidationErrors | null {
    return customValidator()(control)
  }

}
