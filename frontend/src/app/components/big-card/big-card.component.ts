import { Component, ElementRef, Input, QueryList, ViewChildren, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NextBtnComponent } from '../next-btn/next-btn.component';
import { FilterRent, Post } from '../../interfaces/interface';
import { SelectCardDirective } from '../../directives/select-card.directive'
import { SetService } from '../../services/set.service';

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

  constructor(){

  }

  getIdCard(){
    if (!this.setId.has(this.card.id)){
      this.setId.add(this.card.id)
    }
    else{
      this.setId.delete(this.card.id)
    }

  }

  @ViewChildren('image') images!: QueryList<ElementRef>;
  imageList: string[] = [
    'https://salon.ru/storage/thumbs/gallery/631/630382/835_3500_s265.jpg',
    'https://salon.ru/storage/thumbs/gallery/631/630382/835_3500_s265.jpg',
    'https://salon.ru/storage/thumbs/gallery/631/630382/835_3500_s265.jpg',
    'https://salon.ru/storage/thumbs/gallery/631/630382/835_3500_s265.jpg',
  ];

  currentIndex = 0;

  ngAfterViewInit() {
    setInterval(() => this.scrollImages(), 5000);
  }

  scrollImages() {
    if (this.images) {
      const imageArray = this.images.toArray();
      this.currentIndex = (this.currentIndex+1) % imageArray.length;
      const currentImage = imageArray[this.currentIndex].nativeElement;
      currentImage.scrollIntoView({ behavior: 'smooth', inline: 'start', block: "center" });
    }
  }
}

