import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { SelectRentComponent } from './select-rent/select-rent.component';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { CommonModule } from '@angular/common';
import { RegistrationPageComponent } from './registration-page/registration-page.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SelectRentComponent, AboutUserComponent, MatchPageComponent, RegistrationPageComponent, HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}

