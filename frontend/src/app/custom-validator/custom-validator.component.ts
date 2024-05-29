import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function customValidator(): ValidatorFn{
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value

    const hasUpperCase = /[A-Z]+/.test(value)
    const hasLowerCase = /[a-z]+/.test(value)
    const hasNum = /[0-9]+/.test(value)
    // const specSymphol = /[#?!@$%^&*-]+/.test(value)
    const passwordValid =  hasLowerCase && hasUpperCase && hasNum
    return !passwordValid ? { passwordStrength: true }: null
  }

}

export const conformPassword: ValidatorFn = (control: AbstractControl): ValidationErrors | null =>{
  return control.value.password == control.value.passwordConfirm ? null: {PasswordDoNotMatch: true}
}
