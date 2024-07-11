import { Routes } from '@angular/router';
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
import { LayoutComponent } from './layout/layout.component';
import { OwnerProfileComponent } from './owner-profile/owner-profile.component';
import { RenterProfileComponent } from './renter-profile/renter-profile.component';


export const routes: Routes = [

  {path:'', redirectTo: "/login", pathMatch: 'full'},
  {path:'', loadChildren:() => import('./authentication/authentication.module').then (m => m.AuthenticationModule) },
  {path:'', component: LayoutComponent, children: [
    {path:'profile', component: RenterProfileComponent},
    {path:'select-rent', loadChildren:() => import('./select-rent-page/select-rent.module').then (m => m.SelectRentModule)},
    {path:'match', component: MatchPageComponent},
    {path:'suggestion', component: SuggestionPageComponent},
    {path:'image', component: ImageScrollerComponent},
    {path:'owner', component: OwnerProfileComponent},
    {path:'apartment-edit/:id', component: ApartmentEditComponent},
    {path:'apartment-edit', component: ApartmentEditComponent},
    {path:'room-edit', component: RoomEditComponent},
    {path:'post-apartment', component: PostApartmentComponent},
    {path:'successful-post', component: SuccessfulPostComponent},
    {path:'apartment-info', component: ApartmentInfoComponent},
    {path:'test/:id', component: TestDetailComponent},
    {path:'app-image-scroller', component:ImageScrollerComponent},
  ], canActivate: [authGuardFn]},
  {path:'**', component: NotFoundPageComponent},
];


