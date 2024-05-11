import { Component, OnInit } from '@angular/core';
import { SortBarComponent } from '../components/sort-bar/sort-bar.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { PostService } from '../requests/services/post/post.service';
import { NgArrayPipesModule } from 'ngx-pipes';
import { FilterRent, Post } from '../interfaces/interface';
import { FilterPipe } from '../filter.pipe';


@Component({
  selector: 'app-select-rent',
  standalone: true,
  imports: [SortBarComponent, BigCardComponent, FilterPipe ,NgArrayPipesModule, NextBtnComponent, CommonModule],
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
}
}

