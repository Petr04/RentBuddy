import { CommonModule } from '@angular/common';
import { Component, QueryList, ViewChildren, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-image-scroller',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app-image-scroller.component.html',
  styleUrl: './app-image-scroller.component.css'
})
export class ImageScrollerComponent implements AfterViewInit {
  @ViewChildren('image') images!: QueryList<ElementRef<HTMLImageElement>>;

  ngAfterViewInit() {
    setInterval(() => this.scrollImages(), 5000);
  }

  imageList: string[] = [
    'https://i.pinimg.com/236x/5b/6e/ca/5b6eca63605bea0eeb48db43f77fa0ce.jpg',
    'https://i.pinimg.com/236x/24/15/21/24152197af38deb718eb730992d441d0.jpg',
    'https://i.pinimg.com/236x/2a/f5/3d/2af53d8f1be483dd0e05b7b18142c33c.jpg',
  ];

  currentIndex = 0;

  scrollImages() {
    if (this.images) {
      const imageArray = this.images.toArray();
      this.currentIndex = (this.currentIndex + 1) % imageArray.length;
      const currentImage = imageArray[this.currentIndex].nativeElement;
      currentImage.scrollIntoView({ behavior: 'smooth', inline: 'start' });
    }
  }
}
