import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public isUserLoggedIn = new BehaviorSubject<boolean>(false)
  // constructor(private _httpCLient: HttpClient) { }
  // public getAccount(): Observable<[]>{
  //   return this._httpCLient.get<[]>('http://localhost:5000/api/User')
  // }
  public login(): void{
    this.isUserLoggedIn.next(true)
  }
}
