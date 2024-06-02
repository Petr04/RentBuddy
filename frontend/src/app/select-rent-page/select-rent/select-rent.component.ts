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

export class SelectRentComponent implements OnInit{
  protected Cards$?: Observable<Post[]>
  public setId = inject(SetService)
  protected testObj?: Post[]


  filterData:FilterRent = {
    city: '',
    inhabitantsCount: 0,
    square: 0,
    minPrice: 0,
    maxPrice: 0
  }

  public handleFilterChange(filterData: FilterRent){
    this.filterData = filterData
  }


  constructor(private postService:PostService){

  }

  ngOnInit() {
    this.Cards$ = this.postService.getPosts()
  }

  printId(){
    const arrayId: string[] = Array.from(this.setId)
    console.log(arrayId)
    this.postService.postListRooms(arrayId).subscribe()
  }

  buttonText:string ='Далее'
}

