import { Component, OnInit, NgZone, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { AuthService } from '../../services/auth.service';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { AuthService } from '../../services/auth.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-google-login',
  standalone: true,
  templateUrl: './google-login.component.html',
  styleUrl: './google-login.component.css'
})
export class GoogleLoginComponent implements OnInit {
  @Output()
  onSuccess: EventEmitter<any> = new EventEmitter();

  @Output()
  onError: EventEmitter<any> = new EventEmitter();

  constructor(
    private fb: FormBuilder,
    private service: AuthService,
    private _ngZone: NgZone,
  ) {}

  ngOnInit(): void {
    // @ts-ignore
    window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: environment.googleAuthClientId,
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true,
        use_fedcm_for_prompt: false,
      });
      // @ts-ignore
      google.accounts.id.renderButton(
        // @ts-ignore
        document.getElementById("googleLoginButton"),
        { theme: "outline", size: "large" }
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {
      });
    };
  }

  async handleCredentialResponse(response: CredentialResponse) {
    await this.service.loginWithGoogle(response.credential).subscribe(
      (res: any) => {
        this.onSuccess.emit(null);
      },
      (error: any) => {
        console.log(error);
        this.onError.emit(null);
      },
    );
  }
}
