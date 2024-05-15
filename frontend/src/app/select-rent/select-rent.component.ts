import { Component, OnInit, Input } from '@angular/core';
import { SortBarComponent } from '../components/sort-bar/sort-bar.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Post, PostService } from '../requests/services/post/post.service';


@Component({
  selector: 'app-select-rent',
  standalone: true,
  imports: [SortBarComponent, BigCardComponent, NextBtnComponent, CommonModule],
  templateUrl: './select-rent.component.html',
  styleUrl: './select-rent.component.css'
})
export class SelectRentComponent{

}

