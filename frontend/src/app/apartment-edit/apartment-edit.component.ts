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
      address: new FormControl('', Validators.required),
      currentFloor: new FormControl('', Validators.required),
      roomsCount: new FormControl('', Validators.required),
      // square: new FormControl('', Validators.required),
      bathroom: new FormControl(false),
      bathroomAmount: new FormControl('', Validators.required),
      technique: new FormControl([]),
      wifi: new FormControl(false),
      floorMax: new FormControl('', Validators.required),
      passengerElevator: new FormControl(false),
      serviceElevator: new FormControl(false),
      parking: new FormControl('', Validators.required),
      courtyard: new FormControl('', Validators.required),
      sportsGround: new FormControl(false),
      maxGuests: new FormControl('', Validators.required),
      petAllowed: new FormControl(false),
      smokingAllowed: new FormControl(false),
      photos: new FormControl([]),
      description: new FormControl('', Validators.required),
      rooms: new FormControl([]),
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
    this.apartmentForm.value.bathroom = this.bathroomBool
    this.apartmentForm.value.wifi = this.wifiBool
    this.apartmentForm.value.passengerElevator = this.passengerElevatorBool
    this.apartmentForm.value.serviceElevator = this.serviceElevatorBool
    this.apartmentForm.value.sportsGround = this.sportsGroundBool
    this.apartmentForm.value.petAllowed = this.petAllowedBool
    this.apartmentForm.value.smokingAllowed = this.smokingAllowedBool
    this.apartmentForm.value.technique = this.techniqueForm.value

    // if (this.apartmentForm.invalid || this.apartmentForm.disabled){
    //   this.apartmentForm.markAllAsTouched()
    //   return
    // }
    console.log(this.apartmentForm.value)
  }
}



