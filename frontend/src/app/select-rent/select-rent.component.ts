import { Component, OnInit } from '@angular/core';
import { FilterRent, SortBarComponent } from '../components/sort-bar/sort-bar.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Post, PostService } from '../requests/services/post/post.service';
import { NgArrayPipesModule } from 'ngx-pipes';


@Component({
  selector: 'app-select-rent',
  standalone: true,
  imports: [SortBarComponent, BigCardComponent, NgArrayPipesModule, NextBtnComponent, CommonModule],
  templateUrl: './select-rent.component.html',
  styleUrl: './select-rent.component.css'
})
export class SelectRentComponent implements OnInit{
  public Cards$?: Observable<Post[]>

  filter:FilterRent = {
    city: '',
    inhabitantsCount: 0,
    square: 0
  }

  constructor(private postService:PostService){}

  ngOnInit() {
    this.Cards$ = this.postService.getPosts()
}
}

