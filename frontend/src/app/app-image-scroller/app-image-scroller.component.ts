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
 
  ];

  currentIndex = 0;

  scrollImages() {
  }
}
