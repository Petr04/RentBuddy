import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SortBarComponent } from './sort-bar/sort-bar.component';
import { BigCardComponent } from './big-card/big-card.component';
import { NextBtnComponent } from './next-btn/next-btn.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SortBarComponent,  BigCardComponent, NextBtnComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'rent-buddy';
  public dwelling: Array<Dwelling> = [
    {
      apartment: {
        id:"8707943542546567809797684",
        roomsCount: 2,
        currentFloor: 3,
        maxFloor: 10
      },
      id: "897675431256587680844367587698",
      price: 52000,
      square: 30,
      inhabitantsCount: 1,
      apartmentId: "09856309856387918563256325632",
      address: "г. Бахмут ул. Долика Бибера д.228"
    },
    {
      apartment: {
        id:"8707943542546567809797684",
        roomsCount: 2,
        currentFloor: 3,
        maxFloor: 10
      },
      id: "897675431256587680844367587698",
      price: 52000,
      square: 30,
      inhabitantsCount: 1,
      apartmentId: "09856309856387918563256325632",
      address: "хуй"
    },
    {
      apartment: {
        id:"8707943542546567809797684",
        roomsCount: 2,
        currentFloor: 3,
        maxFloor: 10
      },
      id: "897675431256587680844367587698",
      price: 52000,
      square: 30,
      inhabitantsCount: 1,
      apartmentId: "09856309856387918563256325632",
      address: "хуйzzzzzzz"
    }
  ];
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
