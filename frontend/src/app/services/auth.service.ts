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
            if (typeof window !== 'undefined') {
              localStorage.setItem('auth-token', token)
              localStorage.setItem('userId', userId)
            }
          }
        )
      )
  }

  logout(): void {
    if (typeof window !== 'undefined') {
      localStorage.removeItem('auth-token');
      localStorage.removeItem('userId');
    }
  }

  getToken(): string | null{
    let token = null
    if (typeof window !== 'undefined') {
      token = localStorage?.getItem('auth-token')
    }
    return token;
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  getUserId(): string | null{
    let id = null
    if (typeof window !== 'undefined') {
      id = localStorage?.getItem("userId")
    }
    return id
  }

}
