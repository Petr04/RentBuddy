import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { FilterRent } from '../interfaces/interface';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private filterSubject = new BehaviorSubject<FilterRent>({
    city: '',
    inhabitantsCount: 0,
    square: 0,
    minPrice: 0,
    maxPrice:0

  })

  updateFilter(newFilter: FilterRent) {
    this.filterSubject.next(newFilter)
  }

  getFilter(): FilterRent {
    return this.filterSubject.getValue()
  }

}
