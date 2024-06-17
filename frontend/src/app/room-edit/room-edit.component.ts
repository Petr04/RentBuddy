import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {RouterLink} from "@angular/router";
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-room-edit',
  standalone: true,
  imports: [
    NextBtnComponent,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './room-edit.component.html',
  styleUrl: './room-edit.component.css'
})
export class RoomEditComponent {
  roomForm!: FormGroup
  techniqueForm!: FormGroup
  furnitureForm!: FormGroup

  constructor(private _postService: PostService ){
    this.roomForm = new FormGroup({
      apartmentId: new FormControl(''),
      square: new FormControl('', Validators.required),
      inhabitantsCount: new FormControl('', Validators.required),
      imageLink: new FormControl(''),
      aboutRoom: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      technicTypes: new FormControl([]),
      furnitureTypes: new FormControl([]),
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
    // this.roomForm.value.technicTypes = this.techniqueForm.value
    // this.roomForm.value.furnitureTypes = this.furnitureForm.value
    this.roomForm.disable()
    this.roomForm.patchValue({
      apartmentId:localStorage.getItem('apartmentId')
    })
    this._postService.postRoom(this.roomForm.value).subscribe()
    this.roomForm.enable()
  }
}
