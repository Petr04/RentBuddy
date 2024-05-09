import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

export interface FilterRent{
  city:string
  inhabitantsCount: number,
  square: number,
}

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
    city: ' ',
    inhabitantsCount: 0,
    square: 0
  }

  checkFilter(){
    console.log(this.filterObj)
  }

}



