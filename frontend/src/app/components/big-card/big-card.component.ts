import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectRentComponent } from '../../select-rent/select-rent.component';
import { FilterRent, SortBarComponent } from '../sort-bar/sort-bar.component';
import { NextBtnComponent } from '../next-btn/next-btn.component';
import { Post } from '../../requests/services/post/post.service';





@Component({
  selector: 'app-big-card',
  standalone: true,
  imports: [CommonModule, SelectRentComponent, SortBarComponent ,BigCardComponent, NextBtnComponent],
  templateUrl: './big-card.component.html',
  styleUrl: './big-card.component.css'
})



export class BigCardComponent {


  @Input() card!: Post
  @Input() filterObj!:FilterRent
}
