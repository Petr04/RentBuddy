import { Component, signal, Signal } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { User, UserProfile } from '../interfaces/interface';
import { animate, keyframes, transition, trigger } from '@angular/animations';
import * as kf from '../keyframes/keyframes';
import { SelectCardDirective } from '../directives/select-card.directive';
import {RouterLink} from "@angular/router";
import { PostService } from '../services/post.service';
import { CommonModule } from '@angular/common';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';

@Component({
  selector: 'app-match-page',
  standalone: true,
  imports: [SelectCardDirective, RouterLink, CommonModule, NextBtnComponent],
  templateUrl: './match-page.component.html',
  styleUrl: './match-page.component.css',
  animations: [
    trigger('cardAnimator', [
      transition('* => swiperight', animate(600, keyframes(kf.swiperight))),
      transition('* => swipeleft', animate(600, keyframes(kf.swipeleft)))
    ])
  ]
})
export class MatchPageComponent {
  protected usersForMatching$?: Observable<UserProfile[]>
  protected userList?: UserProfile[]
  public parentSubject:Subject<string> = new Subject();
  public length: number = 0
  public index: number = 0;
  public animationState!: string;
  public showInfo = signal(false)

  constructor(private readonly postService: PostService) {

  }

  ngOnInit() {
    this.usersForMatching$ =  this.postService.getUsersMatches()
    this.postService.getUsersMatches().subscribe(res => this.length = res.length)
  }

  public startAnimation(state: string, matchId: string) {
    if (!this.animationState) {
      this.animationState = state;
      if (this.length != this.index){
        this.postService.like(matchId).subscribe()
        this.index++
      }
      else{
        alert("Пользователи закончились")
      }
    }
  }

  public resetAnimationState() {
    this.animationState = '';
    // this.index++;
  }

  public toblackList(){

  }

  ngOnDestroy() {
    this.parentSubject.unsubscribe();
  }

}
