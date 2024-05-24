import { Component, OnInit, inject } from '@angular/core';
import { Post } from '../interfaces/interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FLAT_PROVIDER, FLAT_TOKEN } from '../services/getCard.service';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

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
  public _account = inject(AccountService)
  private readonly router = inject(Router)
  constructor() { }
  ngOnInit(): void {

  //   this.card$ = this._card.getPostByID('a61618b9-c076-471d-a2b7-14b3d593a6b9')
  }

  loginIn(){
    this._account.login()
    this.router.navigate(['/match'])
  }

  logout(){
    this._account.logout()
  }

  cardSubmit(){
    console.log(this.card$)
  }

}
