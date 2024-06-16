import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Post, Room, SuggestionRoom, User, UserProfile } from '../interfaces/interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _httpCLient: HttpClient) {

  }
  public getUserId(){
    return localStorage?.getItem('userId')
  }

  public getRooms(): Observable<Post[]>{
    return this._httpCLient.get<Post[]>('api/Room')
  }

  public getRoomByID(id: string): Observable<Post>{
    return this._httpCLient.get<Post>(`api/Room/${id}`)
  }

  public getUsers(): Observable<User>{
    return this._httpCLient.get<User>('api/Users')
  }

  public getUserById():Observable<UserProfile>{
    return this._httpCLient.get<UserProfile>(`api/Users/${this.getUserId()}`)
  }

  public postUser(obj: UserProfile){
    return this._httpCLient.post('api/Users', obj)
  }

  public postFavoriteRooms(arr: Array<string>){
    return this._httpCLient.post(`api/FavoriteRooms/${this.getUserId()}/AddRoomToFavorites`, arr)
  }

  public getUsersMatches():Observable<UserProfile[]>{
    return this._httpCLient.get<UserProfile[]>(`api/Users/${this.getUserId()}/matches`)
  }

  public like(targetId: string):Observable<{}>{
    return this._httpCLient.post(`api/FavoriteUsers/${this.getUserId()}/AddUserToFavourities/${targetId}`, {"currentUserId":this.getUserId(), "targetUserId": targetId })
  }

  public getSuitableRoom():Observable<SuggestionRoom>{
    return this._httpCLient.get<SuggestionRoom>(`api/Users/GetSuitableRoom/${this.getUserId()}`)
  }

  public getApartmentById(id: string):Observable<any>{
    return this._httpCLient.get<any>(`api/Apartment/${id}`)
  }

  public postApartment(obj: any):Observable<any>{
    return this._httpCLient.post<any>('api/Apartment', obj).
    pipe(
      tap(
        ({id}) => {
          localStorage.setItem('apartmentId', id)
        }
      )
    )
  }

  public postRoom(obj: any):Observable<any>{
    return this._httpCLient.post<any>('api/Room', obj)
  }

  public getHostsApartment(): Observable<any>{
    return this._httpCLient.get<any>(`api/Apartment/${this.getUserId()}/gethostsapatment`)
  }

}
