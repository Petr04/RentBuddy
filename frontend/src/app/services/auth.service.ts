import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { User } from '../interfaces/interface';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router){
  }

  register(user: User): Observable<User> {
    return this.http.post<User>('api/Users/register', user)
  }

  login(user: User): Observable<{token: string, userId: string}>{

    return this.http.post<{token: string, userId: string}>('api/Users/login', user)
      .pipe(
        tap(
          ({token, userId}) => {
            localStorage.setItem('auth-token', token)
            localStorage.setItem('userId', userId)
          }
        )
      )
  }

  logout(): void {
    localStorage.removeItem('auth-token');
    localStorage.removeItem('userId');
  }

  getToken(): string | null{
    return localStorage?.getItem('auth-token');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  getUserId(): string | null{
    return localStorage?.getItem("userId")
  }

}
