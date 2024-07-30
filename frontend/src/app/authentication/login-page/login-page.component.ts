import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css',
})
export class LoginPageComponent implements OnDestroy, OnInit {

  private aSub!: Subscription
  public authorizationForm!: FormGroup
  public visible:boolean = true;
  public changetype:boolean =true;

  constructor(private readonly authService: AuthService , private readonly router: Router){
    this.authorizationForm = new FormGroup({
      email: new FormControl("", [Validators.required ,Validators.email]),
      password: new FormControl("")
    })
  }
  ngOnInit(): void {
    if (this.authService.isAuthenticated()){
       this.router.navigate(['/profile'])
    }
  }

  ngOnDestroy() {
    if (this.aSub){
      this.aSub.unsubscribe()
    }
  }

  public confirmAuth():void{
    if (this.authorizationForm.disabled){
      this.authorizationForm.markAllAsTouched()
      return
    }
    else{
      this.authorizationForm.disable()
      this.aSub = this.authService.login(this.authorizationForm.value).subscribe({
        next: () => this.router.navigate(['/profile']),
        error: (err) => {
          this.authorizationForm.enable()
        }
      })
    }
  }

  public onGoogleAuthSuccess(): void {
    this.router.navigate(['/profile']);
  }

  public onGoogleAuthError(): void {
    console.log('error logging using google');
  }

  public viewpass(){
    this.visible = !this.visible;
    this.changetype = !this.changetype;
  }
}
