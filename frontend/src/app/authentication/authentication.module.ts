import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { PasswordStrengthDirective } from '../directives/password-strenght-validator.directive';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { CodeInputModule } from 'angular-code-input';
import { VerificationPageComponent } from './verification-page/verification-page.component';
import {TuiPushModule} from "@taiga-ui/kit";
import {TuiRootModule} from "@taiga-ui/core";

const routes:Routes = [
  {path: 'login', component: LoginPageComponent },
  {path:'registration', component: RegistrationPageComponent, data: {header: "d111111" }},
  {path:'verification', component: VerificationPageComponent}
]

@NgModule({
  declarations: [LoginPageComponent, RegistrationPageComponent, VerificationPageComponent],
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    FormsModule,
    NextBtnComponent,
    PasswordStrengthDirective,
    CodeInputModule,
    RouterModule.forChild(routes),
    TuiPushModule,
    TuiRootModule
  ],
  exports: [LoginPageComponent, RegistrationPageComponent],
})
export class AuthenticationModule { }
