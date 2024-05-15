import { Component } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about-user',
  standalone: true,
  imports: [NextBtnComponent, CommonModule],
  templateUrl: './about-user.component.html',
  styleUrl: './about-user.component.css'
})
export class AboutUserComponent {

}
