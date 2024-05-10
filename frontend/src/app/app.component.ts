import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SelectRentComponent } from './select-rent/select-rent.component';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SelectRentComponent, AboutUserComponent, MatchPageComponent ,HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}

export interface Dwelling {
  apartment: Apartment;
  id: string;
  price: number;
  square: number;
  inhabitantsCount: number;
  apartmentId: string;
  address: string;
}

export interface Apartment {
  id: string;
  roomsCount: number;
  currentFloor: number;
  maxFloor: number;
}
