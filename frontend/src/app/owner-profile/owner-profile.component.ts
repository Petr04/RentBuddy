import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { map, Observable } from 'rxjs';
import { Apartment } from '../interfaces/interface';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-owner-profile',
  standalone: true,
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
  providers: [DatePipe],
  templateUrl: './owner-profile.component.html',
  styleUrl: './owner-profile.component.css'
})

export class OwnerProfileComponent implements OnInit {
  public profileForm!: FormGroup
  protected hostApartment$?: Observable<Apartment[]>

  constructor(private readonly postService: PostService, private readonly auth: AuthService, private readonly datePipe: DatePipe){
    this.profileForm = new FormGroup({
      image: new FormControl(),
      lastname: new FormControl(),
      name: new FormControl(),
      birthDate: new FormControl(),
      telegramUsername: new FormControl(),
    })
  }

  ngOnInit(): void {
    this.postService.getHostsApartment().subscribe()
    this.postService.getUserById().subscribe(res => {
      this.profileForm.patchValue({
        name: res.name,
        lastname: res.lastname,
        birthDate: this.datePipe.transform(res.birthDate, 'yyyy-MM-dd'),
        telegramUsername: res.telegramUsername,
      })
    })

    this.hostApartment$ = this.postService?.getHostsApartment().pipe(
      map((data: any)=> data?.hostsApartments )
    )
  }

  public uploadImage(event: Event){

  }

  public logout(){
    this.auth.logout()
  }

  saveData() {
    this.profileForm.disable
    this.profileForm.value.id = this.postService.getUserId()
    this.postService.postUser(this.profileForm.value).subscribe()
    console.log(this.profileForm);
  }
}
