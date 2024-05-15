import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function customValidator(regExp:RegExp): ValidatorFn{
  return (control: AbstractControl): ValidationErrors | null => {
    const forbidden = regExp.test(control.value)
    return !forbidden ? { forbiddenValue: {value: control.value} }: null
  }

}

export const conformPassword: ValidatorFn = (control: AbstractControl): ValidationErrors | null =>{
  return control.value.userPassword == control.value.userPassword2 ? null: {PasswordDoNotMatch: true}
}
