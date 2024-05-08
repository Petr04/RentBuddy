import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectRentComponent } from '../../select-rent/select-rent.component';
import { SortBarComponent } from '../sort-bar/sort-bar.component';
import { NextBtnComponent } from '../next-btn/next-btn.component';
import { Observable } from 'rxjs';
import { Post, PostService } from '../../requests/services/post/post.service';


@Component({
  selector: 'app-big-card',
  standalone: true,
  imports: [CommonModule, SelectRentComponent, SortBarComponent, BigCardComponent, NextBtnComponent],
  templateUrl: './big-card.component.html',
  styleUrl: './big-card.component.css'
})


export class BigCardComponent implements OnInit{
  public Cards$?: Observable<Post[]>

  constructor(private postService:PostService){}

  ngOnInit() {
      this.Cards$ = this.postService.getPosts()
  }



}
