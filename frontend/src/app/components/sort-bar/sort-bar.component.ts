import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterRent } from '../../interfaces/interface';



@Component({
  selector: 'app-sort-bar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sort-bar.component.html',
  styleUrl: './sort-bar.component.css'
})



export class SortBarComponent {
  public isOpen: boolean = false;

  filterObj: FilterRent = {
    city: 'Екб',
    inhabitantsCount: 1,
    square: 2
  }

  bank: string = 'alpha'

  @Output() filterChange  = new EventEmitter<FilterRent>();

  fitlerEvent(){
    this.filterChange.emit(this.filterObj)
  }
}



