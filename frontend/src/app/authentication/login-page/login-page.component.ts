import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  standalone: false,
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnDestroy, OnInit {

  aSub!: Subscription
  public authorizationForm!: FormGroup
  visible:boolean = true;
  changetype:boolean =true;

  constructor(private authService: AuthService , private router: Router){
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

  public viewpass(){
    this.visible = !this.visible;
    this.changetype = !this.changetype;
  }
}
