import { Component } from '@angular/core'; ;
import { FormControl, FormGroup, Validators} from '@angular/forms';
import { conformPassword } from '../../custom-validator/custom-validator.component';
@Component({
  selector: 'app-registration-page',
  standalone: false,
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
