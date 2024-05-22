import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public isUserLoggedIn = new BehaviorSubject<boolean>(false)

  public login(): void{
    this.isUserLoggedIn.next(true)
  }

  public logout(): void{
    this.isUserLoggedIn.next(false)

  }
}
