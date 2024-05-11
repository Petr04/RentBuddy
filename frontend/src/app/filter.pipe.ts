import { Pipe, PipeTransform } from '@angular/core';
import { FilterRent, Post } from './interfaces/interface';

@Pipe({
  name: 'filter',
  standalone: true,
  pure: false
})
export class FilterPipe implements PipeTransform {

  transform(cards: Post[], filters: FilterRent): Post[] {
    return cards.filter(card => {
      return (filters.square == 0 || filters.square == null &&
        filters.inhabitantsCount == 0 || filters.inhabitantsCount == null &&
        filters.maxPrice == 0 || filters.maxPrice == null) ||
      (card.square== filters.square ||  card.inhabitantsCount == filters.inhabitantsCount || (filters.minPrice<card.price && card.price<filters.maxPrice))
    });
  }
}
// return card.square== filters.square ||  card.inhabitantsCount == filters.inhabitantsCount || (filters.minPrice<card.price && card.price<filters.maxPrice)
