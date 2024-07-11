import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterRent } from '../interfaces/interface';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';

@Component({
  selector: 'app-filter-rents',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NextBtnComponent],
  templateUrl: './filter-rents.component.html',
  styleUrl: './filter-rents.component.css'
})
export class FilterRentsComponent {
  city:FormControl<string | null> = new FormControl('')
  inhabitantsCount:FormControl<number> = new FormControl()
  square:FormControl<number> = new FormControl()
  minPrice:FormControl<number> = new FormControl()
  maxPrice:FormControl<number> = new FormControl()

  filterObj: FilterRent = {
    city: '',
    inhabitantsCount: 0,
    square: 0,
    minPrice: 0,
    maxPrice:0
  }

  @Output() filterChange  = new EventEmitter<FilterRent>();

  fitlerEvent(){
    this.filterObj.city = this.city.value
    this.filterObj.inhabitantsCount = this.inhabitantsCount.value ? +this.inhabitantsCount.value : this.inhabitantsCount.value
    this.filterObj.square = this.square.value ? +this.square.value:this.square.value
    this.filterObj.minPrice = this.minPrice.value ? +this.minPrice.value:this.minPrice.value
    this.filterObj.maxPrice = this.maxPrice.value ? +this.maxPrice.value:this.maxPrice.value
    this.filterChange.emit(this.filterObj)
    console.log(this.filterObj)
  }
}
