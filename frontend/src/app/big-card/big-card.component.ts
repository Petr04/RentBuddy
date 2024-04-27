import { Component, OnInit, Input } from '@angular/core';
import { Dwelling } from '../app.component';
import { Room } from '../apartment';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Post, PostService } from '../requests/services/post/post.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-big-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './big-card.component.html',
  styleUrl: './big-card.component.css'
})


export class BigCardComponent implements OnInit{

  public Posts$?: Observable<Post[]>

  constructor(private postService:PostService){}

  ngOnInit() {
      this.Posts$ = this.postService.getPosts()
  }
  @Input()
  public dwelling! : Dwelling;

}
