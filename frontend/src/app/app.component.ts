import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { CommonModule } from '@angular/common';
import { SelectRentModule } from './select-rent-page/select-rent.module';
import { AuthenticationModule } from './authentication/authentication.module';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SelectRentModule, AboutUserComponent, MatchPageComponent, AuthenticationModule, HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}

