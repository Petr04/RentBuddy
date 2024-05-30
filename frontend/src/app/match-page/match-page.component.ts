import { Component, Input } from '@angular/core';
import { Subject } from 'rxjs';
import { User } from '../interfaces/interface';
import { animate, keyframes, transition, trigger } from '@angular/animations';
import * as kf from '../keyframes/keyframes';
import { SelectCardDirective } from '../directives/select-card.directive';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-match-page',
  standalone: true,
  imports: [SelectCardDirective, RouterLink],
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
  data: {id: number,picture: string, age: number, name: string, gender: string}[] = [
    {
      "id": 0,
      "picture": "https://placehold.it/350x349",
      "age": 23,
      "name": "Candace Coffey",
      "gender": "female"
    }
  ]
  parentSubject:Subject<string> = new Subject();

  public users:  {id: number,picture: string, age: number, name: string, gender: string}[]= this.data;
  public index = 0;

  animationState!: string;

  constructor() { }

  cardAnimation(value: any) {
    this.parentSubject.next(value);
  }
  ngOnInit() {


  }

  startAnimation(state: string) {
    if (!this.animationState) {
      this.animationState = state;
    }
  }

  resetAnimationState(state: any) {
    this.animationState = '';
    this.index++;
  }


  ngOnDestroy() {
    this.parentSubject.unsubscribe();
  }



}
