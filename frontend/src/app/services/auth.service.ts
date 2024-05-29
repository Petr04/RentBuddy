import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, tap, throwError } from 'rxjs';
import { User } from '../interfaces/interface';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient){
  }

  register(user: User): Observable<User> {
    return this.http.post<User>('http://localhost:5000/api/Users/register', user)
  }

  login(user: User): Observable<{token: string}>{

    return this.http.post<{token: string}>('http://localhost:5000/api/Users/login', user)
      .pipe(
        tap(
          ({token}) => {
            localStorage.setItem('auth-token', token)
          }
        )
      )
  }

  logout(): void {
    localStorage.removeItem('auth-token');
  }

  getToken(): string | null{
    return localStorage.getItem('auth-token');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

}
