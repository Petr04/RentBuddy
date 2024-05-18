import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NextBtnComponent } from '../next-btn/next-btn.component';
import { FilterRent, Post } from '../../interfaces/interface';
import { SelectCardDirective } from '../../directives/select-card.directive' 




@Component({
  selector: 'app-big-card',
  standalone: true,
  imports: [CommonModule, NextBtnComponent, SelectCardDirective],
  templateUrl: './big-card.component.html',
  styleUrl: './big-card.component.css'
})

export class BigCardComponent {
  @Input() card!: Post
  @Input() filterObj!:FilterRent

  private arraySelectedCards: Array<string> = [];

  isSelected: boolean = false
  getIdCard(){
    // if () {

    // }

  }

  set(){
    console.log(this.arraySelectedCards)
  }
}
