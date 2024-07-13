import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl} from '@angular/forms';
import { FilterRent } from '../../interfaces/interface';
import { FilterService } from '../../services/filter.service';

@Component({
  selector: 'app-sort-bar',
  standalone: false,
  templateUrl: './sort-bar.component.html',
  styleUrl: './sort-bar.component.css'
})

export class SortBarComponent {
  public isOpen: boolean = false;

  constructor() {

  }
}



