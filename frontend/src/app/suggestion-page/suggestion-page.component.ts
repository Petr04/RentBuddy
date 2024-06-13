import { Component, OnInit } from '@angular/core';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { Post, SuggestionRoom } from '../interfaces/interface';
import {RouterLink} from "@angular/router";
import { Observable, map } from 'rxjs';
import { PostService } from '../services/post.service';
import { CommonModule } from '@angular/common';
import { LetDirective } from '../directives/struct.directive';

@Component({
  selector: 'app-suggestion-page',
  standalone: true,
  imports: [NextBtnComponent, BigCardComponent, RouterLink, CommonModule, LetDirective],
  templateUrl: './suggestion-page.component.html',
  styleUrl: './suggestion-page.component.css'
})
export class SuggestionPageComponent implements OnInit{
  public cardOfUser$?: Observable<Post>

   constructor(private postService: PostService){

   }

  ngOnInit(): void {
    this.cardOfUser$ = this.postService.getSuitableRoom().pipe(
      map((res:SuggestionRoom)=> res?.item1)
    )
    this.postService.getSuitableRoom().subscribe()
  }

}
