import { Component, OnInit } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { Post } from '../interfaces/interface';
import {RouterLink} from "@angular/router";
import { Observable, map } from 'rxjs';
import { PostService } from '../services/post.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-suggestion-page',
  standalone: true,
  imports: [NextBtnComponent, BigCardComponent, RouterLink, CommonModule],
  templateUrl: './suggestion-page.component.html',
  styleUrl: './suggestion-page.component.css'
})
export class SuggestionPageComponent implements OnInit{
  public cardOfUser$?: Observable<Post>

   constructor(private postService: PostService){

   }

  ngOnInit(): void {
    this.cardOfUser$ = this.postService.match().pipe(
      map((res:any)=> res.item1)
    )
    this.postService.match().subscribe(res => console.log(res))
  }

}
