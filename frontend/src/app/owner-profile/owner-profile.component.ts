import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { map, Observable } from 'rxjs';
import { Apartment } from '../interfaces/interface';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-owner-profile',
  standalone: true,
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
  templateUrl: './owner-profile.component.html',
  styleUrl: './owner-profile.component.css'
})

export class OwnerProfileComponent implements OnInit {
  public profileForm!: FormGroup
  protected hostApartment$?: Observable<Apartment[]>

  constructor(private readonly postService: PostService, private readonly auth: AuthService){
    this.profileForm = new FormGroup({

    })
  }

  ngOnInit(): void {
    this.postService.getHostsApartment().subscribe()
    this.hostApartment$ = this.postService?.getHostsApartment().pipe(
      map((data: any)=> data?.hostsApartments )
    )
  }

  public uploadImage(event: Event){

  }

  public logout(){
    this.auth.logout()
  }
}
