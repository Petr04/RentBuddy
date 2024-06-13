import { Component } from '@angular/core';
import {PasswordStrengthDirective} from "../directives/password-strenght-validator.directive";
import {ReactiveFormsModule} from "@angular/forms";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-error-page',
  standalone: true,
  imports: [
    PasswordStrengthDirective,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './error-page.component.html',
  styleUrl: './error-page.component.css'
})
export class ErrorPageComponent {

}
