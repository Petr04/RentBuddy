import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-room-edit',
  standalone: true,
  imports: [
    NextBtnComponent,
    ReactiveFormsModule
  ],
  templateUrl: './room-edit.component.html',
  styleUrl: './room-edit.component.css'
})
export class RoomEditComponent {
  roomForm!: FormGroup
  techniqueForm!: FormGroup
  furnitureForm!: FormGroup

  constructor( ){
    this.roomForm = new FormGroup({
      square: new FormControl('', Validators.required),
      inhabitantsCount: new FormControl('', Validators.required),
      imageLink: new FormControl(''),
      aboutRoom: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      technique: new FormControl([]),
      furniture: new FormControl([]),
    })

    this.techniqueForm = new FormGroup({
      tv: new FormControl(false),
      conditioner: new FormControl(false),
      lamp: new FormControl(false),
      computer: new FormControl(false),
    })

    this.furnitureForm = new FormGroup({
      sofa: new FormControl(false),
      closet: new FormControl(false),
      table: new FormControl(false),
    })
  }

  next(){
    this.roomForm.value.technique = this.techniqueForm.value
    this.roomForm.value.furniture = this.furnitureForm.value

    if (this.roomForm.invalid || this.roomForm.disabled){
      this.roomForm.markAllAsTouched()
      return
    }
    console.log(this.roomForm.value)
  }
}
