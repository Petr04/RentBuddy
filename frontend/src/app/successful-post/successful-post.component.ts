import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";
import {RouterLink} from "@angular/router";
import {Post} from "../interfaces/interface";

@Component({
  selector: 'app-successful-post',
  standalone: true,
  imports: [
    NextBtnComponent,
    RouterLink
  ],
  templateUrl: './successful-post.component.html',
  styleUrl: './successful-post.component.css'
})
export class SuccessfulPostComponent {
  card:Post = {
    "apartment": {
      "id": "0e218c4d-1619-4542-82df-52c8c921a9a1",
      "roomsCount": 3,
      "currentFloor": 9,
      "maxFloor": 12,
      "address": "Ленина 52"
    },
    "id": "369c4a8d-3f4a-499f-be72-a5ad4a9521e0",
    "price": 30000,
    "square": 52,
    "inhabitantsCount": 2,
    'imageLink': '12321',
    "apartmentId": "0e218c4d-1619-4542-82df-52c8c921a9a1"
  }
}
