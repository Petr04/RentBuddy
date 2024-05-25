import { Routes } from '@angular/router';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { SuggestionPageComponent } from './suggestion-page/suggestion-page.component'; ;
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { authGuardFn } from './authorized.guard';
import { TestDetailComponent } from './test-route/test-route.component';

export const routes: Routes = [
  {path:'select-rent', loadChildren:() => import('./select-rent-page/select-rent.module').then (m => m.SelectRentModule)},
  {path:'profile', component: AboutUserComponent, },//canActivate:[authGuardFn]},
  {path:'match', component: MatchPageComponent, canActivate:[authGuardFn]},
  {path:'suggestion', component: SuggestionPageComponent, canActivate: [authGuardFn]},
  {path:'test/:id', component: TestDetailComponent},
  {path:'', redirectTo: "/login", pathMatch: 'full'},
  {path:'', loadChildren:() => import('./authentication/authentication.module').then (m => m.AuthenticationModule)},
  {path:'**', component: NotFoundPageComponent},
];

// https://angdev.ru/archive/angular9/angular-routing-guards/ Guards
// https://metanit.com/web/angular2/7.3.php Route Parameters
