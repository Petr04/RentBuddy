import { Pipe, PipeTransform } from '@angular/core';
import { FilterRent, Post } from './interfaces/interface';

@Pipe({
  name: 'filter',
  standalone: true,
  pure: false
})
export class FilterPipe implements PipeTransform {

  transform(cards: Post[], filters: FilterRent): Post[] {

    const arr = cards.filter(card => {

      const matchesInhabitants = !filters.inhabitantsCount || card.inhabitantsCount === filters.inhabitantsCount;
      const matchesSquare = !filters.square || card.square === filters.square;
      const matchesMinPrice = !filters.minPrice || card.price >= filters.minPrice;
      const matchesMaxPrice = !filters.maxPrice || card.price <= filters.maxPrice
      const hasCity = !filters.city || card.apartment.address.includes(filters.city || "");

      return matchesInhabitants && matchesSquare && matchesMinPrice && matchesMaxPrice && hasCity;

    });
    return arr
  }
}
// return card.square== filterss.square ||  card.inhabitantsCount == filters.inhabitantsCount || (filters.minPrice<card.price && card.price<filters.maxPrice)
