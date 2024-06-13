import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {RouterLink} from "@angular/router";
import { PostService } from '../services/post.service';


@Component({
  selector: 'app-apartment-edit',
  standalone: true,
  imports: [
    NextBtnComponent, CommonModule, ReactiveFormsModule, RouterLink
  ],
  templateUrl: './apartment-edit.component.html',
  styleUrl: './apartment-edit.component.css'
})

export class ApartmentEditComponent {
  apartmentForm!: FormGroup
  techniqueForm!: FormGroup
  bathroomBool = false
  wifiBool = false
  passengerElevatorBool = false
  serviceElevatorBool = false
  sportsGroundBool = false
  petAllowedBool = false
  smokingAllowedBool = false

  constructor(private _postService: PostService){
    this.apartmentForm = new FormGroup({
      id: new FormControl(),
      ownerId: new FormControl(localStorage.getItem("userId")),
      address: new FormControl(''),
      currentFloor: new FormControl(),
      roomsCount: new FormControl(),
      isCombinedBathroom: new FormControl(),
      bathroomCount: new FormControl(),
      technicType: new FormControl([]), //  нужно переделать из массива буллов в массив number
      hasWifi: new FormControl(),

      maxFloor: new FormControl(),
      hasPassengerElevator: new FormControl(),
      hasFreightElevator: new FormControl(),
      parkingType: new FormControl(),//num
      yardType: new FormControl(),
      //sportsGround: new FormControl(false),  нету на беке
      //maxGuests: new FormControl(''),  нету на беке
      hasPet: new FormControl(),
      canUserSmoke: new FormControl(),
      imageLinks: new FormControl(['']),
      aboutApartment: new FormControl(''),
      //rooms: new FormControl([]),
    })
    this.techniqueForm = new FormGroup({
      fridge: new FormControl(false),
      microwave: new FormControl(false),
      washingMachine: new FormControl(false),
      dishwasher: new FormControl(false),
      kitchenStove: new FormControl(false),
    })
  }

  bath(bool:boolean){
    bool? this.bathroomBool = true : this.bathroomBool = false
  }
  wifi(bool: boolean){
    bool? this.wifiBool = true : this.wifiBool = false
  }
  passengerElevator(bool: boolean){
    bool? this.passengerElevatorBool = true : this.passengerElevatorBool = false
  }
  serviceElevator(bool: boolean){
    bool? this.serviceElevatorBool = true : this.serviceElevatorBool = false
  }
  sportsGround(bool: boolean){
    bool? this.sportsGroundBool = true : this.sportsGroundBool = false
  }
  petAllowed(bool: boolean){
    bool? this.petAllowedBool = true : this.petAllowedBool = false
  }
  smokingAllowed(bool: boolean){
    bool? this.smokingAllowedBool = true : this.smokingAllowedBool = false
  }

  next(){
    this.apartmentForm.value.isCombinedBathroom = this.bathroomBool
    this.apartmentForm.value.hasWifi = this.wifiBool
    this.apartmentForm.value.hasPassengerElevator = this.passengerElevatorBool
    this.apartmentForm.value.hasFreightElevator = this.serviceElevatorBool
    //this.apartmentForm.value.sportsGround = this.sportsGroundBool
    this.apartmentForm.value.hasPet = this.petAllowedBool
    this.apartmentForm.value.canUserSmoke = this.smokingAllowedBool
    //this.apartmentForm.value.technique = this.techniqueForm.value

    this.apartmentForm.value.parkingType = +this.apartmentForm.value.parkingType
    this.apartmentForm.value.yardType = +this.apartmentForm.value.yardType
    this.apartmentForm.value.currentFloor = +this.apartmentForm.value.currentFloor
    this.apartmentForm.value.roomsCount = +this.apartmentForm.value.roomsCount
    this.apartmentForm.value.bathroomCount = +this.apartmentForm.value.bathroomCount
    this.apartmentForm.value.maxFloor = +this.apartmentForm.value.maxFloor

    this._postService.postApartment(this.apartmentForm.value).subscribe()
  }
}



