import { Component, OnInit, inject } from '@angular/core';
import { Post } from '../interfaces/interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FLAT_PROVIDER, FLAT_TOKEN } from '../services/get-сard.service';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

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
  public card$?: Observable<Post> = inject(FLAT_TOKEN)
  public _account = inject(AuthService)
  private readonly router = inject(Router)
  constructor() { }
  ngOnInit(): void {

  //   this.card$ = this._card.getRoomByID('a61618b9-c076-471d-a2b7-14b3d593a6b9')
  }

  logout(){
    this._account.logout()
  }

  cardSubmit(){
    
  }

}
