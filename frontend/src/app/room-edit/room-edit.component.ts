import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";

@Component({
  selector: 'app-room-edit',
  standalone: true,
  imports: [
    NextBtnComponent
  ],
  templateUrl: './room-edit.component.html',
  styleUrl: './room-edit.component.css'
})
export class RoomEditComponent {

}
