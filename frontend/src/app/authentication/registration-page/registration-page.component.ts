import { Component, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';
import { conformPassword } from '../../custom-validator/custom-validator.component';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';



@Component({
  selector: 'app-registration-page',
  standalone: false,
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RegistrationPageComponent implements OnDestroy{

  open = false;

  toggle(open: boolean): void {
    this.open = open;
  }

  aSub!: Subscription
  public registrationForm!: FormGroup

  constructor(private auth: AuthService, private router: Router){
    this.registrationForm = new FormGroup(
      {
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl(''),
        passwordConfirm: new FormControl('')
      },
      conformPassword
    );
  }

  ngOnDestroy() {
    if (this.aSub){
      this.aSub.unsubscribe()
    }
  }

  public onSubmit(){
    if (this.registrationForm.invalid || this.registrationForm.disabled){
      this.registrationForm.markAllAsTouched()
      return
    }
    else{
      this.registrationForm.disable()
      this.aSub = this.auth.register(this.registrationForm.value).subscribe({
        next: () => setTimeout(()=>this.router.navigate(['/login']),2000),
        error: (err) => {
          this.registrationForm.enable()
        }
      })
    this.toggle(true)
    }
  }
  visible:boolean = true;
  changetype:boolean =true;

  viewpass(){
    this.visible = !this.visible;
    this.changetype = !this.changetype;
  }
}
