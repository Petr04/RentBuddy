import { Component } from '@angular/core';
import {NextBtnComponent} from "../components/next-btn/next-btn.component";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-apartment-edit',
  standalone: true,
  imports: [
    NextBtnComponent, CommonModule, ReactiveFormsModule
  ],
  templateUrl: './apartment-edit.component.html',
  styleUrl: './apartment-edit.component.css'
})

export class ApartmentEditComponent {
  apartmentForm!: FormGroup
  techniqueForm!: FormGroup

  constructor( ){
    this.apartmentForm = new FormGroup({
      id: new FormControl(''),
      address: new FormControl('', Validators.required),
      currentFloor: new FormControl(null, Validators.required),
      roomsCount: new FormControl(null, Validators.required),
      // square: new FormControl('', Validators.required),
      isCombinedBathroom: new FormControl(false),
      bathroomCount: new FormControl(null, Validators.required),
      technicType: new FormControl([0]), //  нужно переделать из массива буллов в массив number
      hasWifi: new FormControl(false),
      maxFloor: new FormControl(null, Validators.required),
      hasPassengerElevator: new FormControl(false),
      hasFreightElevator: new FormControl(false),
      parkingType: new FormControl(null, Validators.required),//num
      yardType: new FormControl(null, Validators.required),
      //sportsGround: new FormControl(false),  нету на беке
      //maxGuests: new FormControl('', Validators.required),  нету на беке
      hasPet: new FormControl(false),
      canUserSmoke: new FormControl(false),
      imageLinks: new FormControl(['']),
      aboutApartment: new FormControl('', Validators.required),
      //rooms: new FormControl([]),
      ownerId: new FormControl(''),
    })
    this.techniqueForm = new FormGroup({
      fridge: new FormControl(false),
      microwave: new FormControl(false),
      washingMachine: new FormControl(false),
      dishwasher: new FormControl(false),
      kitchenStove: new FormControl(false),
    })
  }

  bathroomBool = false
  bath(bool:boolean){
    bool? this.bathroomBool = true : this.bathroomBool = false
  }
  wifiBool = false
  wifi(bool: boolean){
    bool? this.wifiBool = true : this.wifiBool = false
  }
  passengerElevatorBool = false
  passengerElevator(bool: boolean){
    bool? this.passengerElevatorBool = true : this.passengerElevatorBool = false
  }
  serviceElevatorBool = false
  serviceElevator(bool: boolean){
    bool? this.serviceElevatorBool = true : this.serviceElevatorBool = false
  }
  sportsGroundBool = false
  sportsGround(bool: boolean){
    bool? this.sportsGroundBool = true : this.sportsGroundBool = false
  }
  petAllowedBool = false
  petAllowed(bool: boolean){
    bool? this.petAllowedBool = true : this.petAllowedBool = false
  }
  smokingAllowedBool = false
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
    // if (this.apartmentForm.invalid || this.apartmentForm.disabled){
    //   this.apartmentForm.markAllAsTouched()
    //   return
    // }
    console.log(this.apartmentForm.value)
  }
}



