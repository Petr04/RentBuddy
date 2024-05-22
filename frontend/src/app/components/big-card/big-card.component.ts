import { Component, Input, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NextBtnComponent } from '../next-btn/next-btn.component';
import { FilterRent, Post } from '../../interfaces/interface';
import { SelectCardDirective } from '../../directives/select-card.directive'
import { SetService } from '../../services/set.service';
import { IndexKind } from 'typescript';




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
  public setId = inject(SetService)

  constructor( ){

  }

  getIdCard(){
    if (!this.setId.has(this.card.id)){
      this.setId.add(this.card.id)
    }
    else{
      this.setId.delete(this.card.id)
    }

  }


}
