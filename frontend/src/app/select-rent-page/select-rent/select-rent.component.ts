import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PostService } from '../../services/post.service';
import { FilterRent, Post } from '../../interfaces/interface';

@Component({
  selector: 'app-select-rent',
  standalone: false,
  templateUrl: './select-rent.component.html',
  styleUrl: './select-rent.component.css'
})

export class SelectRentComponent implements OnInit{
  protected Cards$?: Observable<Post[]>

  filterData:FilterRent = {
    city: '',
    inhabitantsCount: 0,
    square: 0,
    minPrice: 0,
    maxPrice: 0
  }

  public handleFilterChange(filterData: FilterRent){
    this.filterData = filterData
    console.log(this.filterData)
  }


  constructor(private postService:PostService){}

  ngOnInit() {
    this.Cards$ = this.postService.getPosts()
    console.log(this.Cards$)
  }

  buttonText:string ='Далее'
}

