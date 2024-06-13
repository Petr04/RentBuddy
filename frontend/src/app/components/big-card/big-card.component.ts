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
    'https://sun9-35.userapi.com/impg/6u7pQchCMWUkMIQQ9ZKFwwGNHQxKLVMe83MCWg/G3tZ-tP0cpo.jpg?size=604x456&quality=95&sign=eef65f9e1decdade460db568254d3646&type=album',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_021.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_015.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_025.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_007.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_016.webp?v=1707763503',
    'https://i.redd.it/xy6v023tymhc1.jpeg',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_017.webp?v=1707763503',
    'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQ-TReD03uugsP5fho8Xphf-3wWRIg0uu1hrBx904tVSh4jLNb1IME00dcTaY2zZZ_u-g&usqp=CAU',
    'https://sun9-11.userapi.com/impg/Va9-tw78kqFHmLRqlqDUzR2kuHIoYMEm0g9bIg/JdcG06_DrDY.jpg?size=807x807&quality=95&sign=91420c2ccc5f15624b52f7cd97833363&c_uniq_tag=ovRFIUMg2KKlgiPiVGxNMKdLKTTKj6mwTQrpA2mcsOs&type=album',
    'https://sticker-collection.com/stickers/plain/Mrpen1s/thumbs/0ab175be-7408-4f86-9c54-09ddbec90c14file_4884361.webp',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_006.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_014.webp?v=1707763503',
    'https://media.tenor.com/rl5HSMVQcbcAAAAe/mr-penis-mister-penis.png',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_008.webp?v=1707763503',
    'https://data.chpic.su/stickers/o/onlymrpenis/onlymrpenis_024.webp?v=1707763503',

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

