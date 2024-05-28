import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl} from '@angular/forms';
import { FilterRent } from '../../interfaces/interface';

@Component({
  selector: 'app-sort-bar',
  standalone: false,
  templateUrl: './sort-bar.component.html',
  styleUrl: './sort-bar.component.css'
})

export class SortBarComponent {
  public isOpen: boolean = false;

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

  }
}



