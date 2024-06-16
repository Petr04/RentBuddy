import { Routes } from '@angular/router';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { SuggestionPageComponent } from './suggestion-page/suggestion-page.component'; ;
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import {ApartmentInfoComponent} from "./apartment-info/apartment-info.component";
import { authGuardFn } from './authorized.guard';
import { TestDetailComponent } from './test-route/test-route.component';
import {ApartmentEditComponent} from "./apartment-edit/apartment-edit.component";
import {RoomEditComponent} from "./room-edit/room-edit.component";
import {PostApartmentComponent} from "./post-apartment/post-apartment.component";
import {SuccessfulPostComponent} from "./successful-post/successful-post.component";
import { ImageScrollerComponent } from './app-image-scroller';
import {ErrorPageComponent} from "./error-page/error-page.component";


export const routes: Routes = [
  {path:'select-rent', loadChildren:() => import('./select-rent-page/select-rent.module').then (m => m.SelectRentModule), canActivate:[authGuardFn]},
  {path:'image', component: ImageScrollerComponent, canActivate: [authGuardFn]},
  {path:'profile', component: AboutUserComponent, canActivate:[authGuardFn] },
  {path:'match', component: MatchPageComponent, canActivate:[authGuardFn]},
  {path:'suggestion', component: SuggestionPageComponent, canActivate: [authGuardFn]},
  {path:'apartment-edit/:id', component: ApartmentEditComponent, canActivate:[authGuardFn]},
  {path:'apartment-edit', component: ApartmentEditComponent, canActivate:[authGuardFn]},
  {path:'room-edit', component: RoomEditComponent, canActivate:[authGuardFn]},
  {path:'post-apartment', component: PostApartmentComponent, canActivate:[authGuardFn]},
  {path:'successful-post', component: SuccessfulPostComponent, canActivate:[authGuardFn]},
  {path:'room-edit', component: RoomEditComponent, canActivate:[authGuardFn]},
  {path:'apartment-info', component: ApartmentInfoComponent, canActivate:[authGuardFn]},
  {path:'test/:id', component: TestDetailComponent, canActivate:[authGuardFn]},
  {path:'app-image-scroller', component:ImageScrollerComponent},
  {path:'error', component: ErrorPageComponent},
  {path:'', redirectTo: "/login", pathMatch: 'full'},
  {path:'', loadChildren:() => import('./authentication/authentication.module').then (m => m.AuthenticationModule)},
  {path:'**', component: NotFoundPageComponent},
];


