import { Component } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';

@Component({
  selector: 'app-registration-page',
  standalone: true,
  imports: [NextBtnComponent],
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {

}
