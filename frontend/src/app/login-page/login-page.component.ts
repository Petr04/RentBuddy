import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { customValidator } from '../custom-validator/custom-validator.component';
import { CLIENT_RENEG_LIMIT } from 'tls';
import { AccountService } from '../requests/services/account/account.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, FormsModule, RouterLink],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {

  public authorizationForm!: FormGroup
  constructor(private _accountSerrvice: AccountService, private router: Router){
    this.authorizationForm = new FormGroup({
      userEmail: new FormControl("", [Validators.required ,Validators.email]),
      userPassword: new FormControl("", customValidator(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/))
    })
  }
  protected confirmAuth(){
    if (this.authorizationForm.invalid){
      this.authorizationForm.markAllAsTouched()
      return
    }
    else{
      this._accountSerrvice.login()
      this.router.navigate(['/profile'])
    }
    console.log(this.authorizationForm.value)
  }
}
