import { Component, OnChanges, OnInit, SimpleChanges, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { PostService } from '../../services/post.service';
import { FilterRent, Post } from '../../interfaces/interface';
import { SetService } from '../../services/set.service';
import { FilterService } from '../../services/filter.service';

@Component({
  selector: 'app-select-rent',
  standalone: false,
  templateUrl: './select-rent.component.html',
  styleUrl: './select-rent.component.css'
})

export class SelectRentComponent implements OnInit {
  public setId = inject(SetService)
  public buttonText:string = 'Далее'
  protected Cards$?: Observable<Post[]>


  constructor(private readonly _postService:PostService, protected _filter: FilterService){

  }
  ngOnInit() {
    this.Cards$ = this._postService.getRooms()
    this._postService.getRooms().subscribe()
  }


  public sendId(){

    const arrayId: string[] = Array.from(this.setId)
    this._postService.postFavoriteRooms(arrayId).subscribe()
  }

}

