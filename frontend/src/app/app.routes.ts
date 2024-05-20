import { Routes } from '@angular/router';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { VerificationPageComponent } from './authentication/verification-page/verification-page.component';
import { SuggestionPageComponent } from './suggestion-page/suggestion-page.component';
import { SelectRentComponent } from './select-rent-page/select-rent/select-rent.component';
import { RegistrationPageComponent } from './authentication/registration-page/registration-page.component';
import { LoginPageComponent } from './authentication/login-page/login-page.component';
import { TestDetailComponent } from './test-route/test-route.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
// import { authorizedGuard } from './authorized.guard';


export const routes: Routes = [
  {path:'select-rent', loadChildren:() => import('./select-rent-page/select-rent.module').then (m => m.SelectRentModule)},
  {path:'profile', component: AboutUserComponent, },//canActivate:[authorizedGuard]},
  {path:'match', component: MatchPageComponent},
  {path:'login', loadChildren:() => import('./authentication/authentication.module').then (m => m.AuthenticationModule)},
  {path:'registration', component: RegistrationPageComponent},
  {path:'verification', component: VerificationPageComponent},
  {path:'suggestion', component: SuggestionPageComponent},
  {path:'test/:id', component: TestDetailComponent},
  {path:'', redirectTo: "/login", pathMatch: 'full'},
  {path:'**', component: NotFoundPageComponent},
];

// https://angdev.ru/archive/angular9/angular-routing-guards/ Guards
// https://metanit.com/web/angular2/7.3.php Route Parameters
