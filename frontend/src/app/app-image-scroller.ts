import { CommonModule } from '@angular/common';
import { Component, QueryList, ViewChildren, ElementRef, Input } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-image-scroller',
  imports:[CommonModule],
  template: `
    <div class="image-container">
      <img #image *ngFor="let image of imageList" [src]="image" class="image-item">
    </div>
  `,
  styles: [`
    .image-container {
      display: flex;
      overflow-x: auto;
      scroll-behavior: smooth;
    }
    .image-item {
      flex: 0 0 auto;
      width: 320px;
      height: 616px;
      margin-right: 10px;
    }
  `],

})
export class ImageScrollerComponent {
  @ViewChildren('image') images!: QueryList<ElementRef>;
  imageList: string[] = [
    'https://i.pinimg.com/236x/5b/6e/ca/5b6eca63605bea0eeb48db43f77fa0ce.jpg',
    'https://i.pinimg.com/236x/24/15/21/24152197af38deb718eb730992d441d0.jpg',
    'https://i.pinimg.com/236x/2a/f5/3d/2af53d8f1be483dd0e05b7b18142c33c.jpg',
  ];

  currentIndex = 0;

  ngAfterViewInit() {
    setInterval(() => this.scrollImages(), 5000);
  }

  scrollImages() {
  }
}
