import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { CommonModule } from '@angular/common';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { VerificationPageComponent } from './verification-page/verification-page.component';
import { SelectRentComponent } from './select-rent/select-rent.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SelectRentComponent, AboutUserComponent, MatchPageComponent, RegistrationPageComponent, LoginPageComponent, VerificationPageComponent, HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}

