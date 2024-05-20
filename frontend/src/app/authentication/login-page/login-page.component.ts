import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { customValidator } from '../../custom-validator/custom-validator.component';
import { CLIENT_RENEG_LIMIT } from 'tls';
import { AccountService } from '../../services/account.service';
import { error } from 'console';
import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  standalone: false,
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnDestroy {

  aSub!: Subscription
  public authorizationForm!: FormGroup

  constructor(private authService: AuthService , private router: Router){
    this.authorizationForm = new FormGroup({
      userEmail: new FormControl("", [Validators.required ,Validators.email]),
      userPassword: new FormControl("")
    })
  }

  ngOnDestroy() {
    if (this.aSub){
      this.aSub.unsubscribe()
    }
  }


  protected confirmAuth(){
    if (this.authorizationForm.invalid || this.authorizationForm.disabled){
      this.authorizationForm.markAllAsTouched()
      return
    }
    else{
      this.authorizationForm.disable()
      this.aSub = this.authService.login(this.authorizationForm.value).subscribe({
        next: () => this.router.navigate(['/select-rent']),
        error: (err) => {
          console.log(err)
          this.authorizationForm.enable()
        }
      })
      // this._accountSerrvice.login()
      // this.router.navigate(['/profile'])
    }
    console.log(this.authorizationForm.value)
  }
}
