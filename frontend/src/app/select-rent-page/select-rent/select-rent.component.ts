import { Component, OnInit, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { PostService } from '../../services/post.service';
import { FilterRent, Post } from '../../interfaces/interface';
import { SetService } from '../../services/set.service';

@Component({
  selector: 'app-select-rent',
  standalone: false,
  templateUrl: './select-rent.component.html',
  styleUrl: './select-rent.component.css'
})

export class SelectRentComponent implements OnInit {
  public setId = inject(SetService)
  public buttonText:string = 'Далее'
  protected Cards$?: Observable<Post[]>
  protected testObj?: Post[]

  filterData:FilterRent = {
    city: '',
    inhabitantsCount: 0,
    square: 0,
    minPrice: 0,
    maxPrice: 0
  }

  constructor(private readonly postService:PostService){

  }

  ngOnInit() {
    this.Cards$ = this.postService.getRooms()
    this.postService.getRooms().subscribe()
  }

  public handleFilterChange(filterData: FilterRent){
    this.filterData = filterData
  }

  public printId(){
    const arrayId: string[] = Array.from(this.setId)
    this.postService.postFavoriteRooms(arrayId).subscribe()
  }

}

