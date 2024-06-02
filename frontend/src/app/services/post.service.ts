import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Post, Room, SuggestionRoom, User, UserProfile } from '../interfaces/interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _httpCLient: HttpClient) {

  }
  public getUserId(){
    return localStorage.getItem('userId')
  }

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
    return this._httpCLient.post(`/api/FavoriteRooms/${this.getUserId()}/AddRoomToFavorites`, arr)
  }

  public getUserForMatch():Observable<UserProfile[]>{
    return this._httpCLient.get<UserProfile[]>(`api/Users/${this.getUserId()}/matches`)
  }


  public like(targetId: string):Observable<{}>{
    return this._httpCLient.post(`api/FavoriteUsers/${this.getUserId()}/AddUserToFavourities/${targetId}`, {"currentUserId":this.getUserId(), "targetUserId": targetId })
  }

  public match():Observable<SuggestionRoom>{
    return this._httpCLient.get<SuggestionRoom>(`api/Users/GetSuitableRoom/${this.getUserId()}`)
  }

}
