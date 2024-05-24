import { HttpClient, HttpHandler, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post, User } from '../interfaces/interface';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _httpCLient: HttpClient) { }

  public getPosts(): Observable<Post[]>{
    return this._httpCLient.get<Post[]>('http://localhost:5000/api/Room')
  }

  public getPostByID(id: string): Observable<Post>{
    return this._httpCLient.get<Post>(`http://localhost:5000/api/Room/${id}`)
  }

  public getUsers(): Observable<User>{
    return this._httpCLient.get<User>('http://localhost:5000/api/User')
  }

  public postUser(userObjL: User){
    return this._httpCLient.post<User>('http://localhost:5000/api/User', userObjL)
  }
}
