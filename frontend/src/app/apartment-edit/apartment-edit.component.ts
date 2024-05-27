import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";

@Component({
  selector: 'app-apartment-edit',
  standalone: true,
  imports: [
    NextBtnComponent
  ],
  templateUrl: './apartment-edit.component.html',
  styleUrl: './apartment-edit.component.css'
})

export class ApartmentEditComponent  {
}
