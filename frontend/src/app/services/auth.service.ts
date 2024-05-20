import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, tap, throwError } from 'rxjs';
import { User } from '../interfaces/interface';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private token: string | null = null

  constructor(private http: HttpClient){
  }

  register(user: User): Observable<User> {
    return this.http.post<User>('http://localhost:5000/api/User', user)
  }

  login(user: User): Observable<{token: string}>{
    return this.http.post<{token: string}>('http://localhost:5000/api/User', user)
      .pipe(
        tap(
          ({token}) => {
            localStorage.setItem('auth-token', token)
          }
        )
      )
  }

  setToken(token: string | null){
    this.token = token
  }

  getToken():string | null {
    return this.token
  }

  isAuthenticated():boolean{
    return !!this.token
  }

  logout(){
    this.setToken(null)
    localStorage.clear()
  }

}
