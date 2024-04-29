import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { cp } from 'fs';
import { Observable } from 'rxjs';


export interface Post{
  apartment: {
    id: string,
    roomsCount: number,
    currentFloor: number,
    maxFloor: number,
    address: string
  },
  apartmentId: string,
  id: string,
  inhabitantsCount: number,
  price: number,
  square: number
}

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _httpCLient: HttpClient) { }

  public getPosts(): Observable<Post[]>{
    return this._httpCLient.get<Post[]>('http://localhost:5000/api/Room')
  }
}
