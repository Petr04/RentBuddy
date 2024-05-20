import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../services/post.service';
import { Post } from '../interfaces/interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FLAT_PROVIDER, FLAT_TOKEN } from '../services/get-rent-token.service';

@Component({
  selector: 'app-test-route',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './test-route.component.html',
  styleUrl: './test-route.component.css',
  providers: [
    FLAT_PROVIDER
  ]
})
export class TestDetailComponent implements OnInit {
  testId!: string;

  card$?: Observable<Post> = inject(FLAT_TOKEN)

  constructor(private route: ActivatedRoute, private _card: PostService) { }

  ngOnInit(): void {
  //   this.route.params.subscribe(params => {
  //     this.testId = params['id']; // Access the 'id' parameter from the URL
  //     console.log('Test ID:', this.testId);
  //   }
  // );
  //   this.card$ = this._card.getPostByID('a61618b9-c076-471d-a2b7-14b3d593a6b9')
  }

  cardSubmit(){
    console.log(this.card$)
  }

}
