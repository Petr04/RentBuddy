import { HttpClient, HttpHandler, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Post, User, UserProfile } from '../interfaces/interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _httpCLient: HttpClient) { }

  public getPosts(): Observable<Post[]>{
    return this._httpCLient.get<Post[]>('/api/Room')
  }

  public getPostByID(id: string): Observable<Post>{
    return this._httpCLient.get<Post>(`/api/Room/${id}`)
  }

  public getUsers(): Observable<User>{
    return this._httpCLient.get<User>('/api/Users')
  }

  public postUser(obj: UserProfile){
    return this._httpCLient.post('/api/Users', obj)
  }

  public postListRooms(arr: Array<string>){
    const id = localStorage.getItem('userId')
    return this._httpCLient.post(`/api/${id}/AddRoomToFavorites`, arr)
  }
}
