import { Routes } from '@angular/router';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { VerificationPageComponent } from './authentication/verification-page/verification-page.component';
import { SuggestionPageComponent } from './suggestion-page/suggestion-page.component';
import { SelectRentComponent } from './select-rent-page/select-rent/select-rent.component';
import { RegistrationPageComponent } from './authentication/registration-page/registration-page.component';
import { LoginPageComponent } from './authentication/login-page/login-page.component';
// import { authorizedGuard } from './authorized.guard';


export const routes: Routes = [
  {path:'select-rent', component: SelectRentComponent},
  {path:'profile', component: AboutUserComponent, },//canActivate:[authorizedGuard]},
  {path:'match', component: MatchPageComponent},
  {path:'registration', component: RegistrationPageComponent},
  {path:'login', component: LoginPageComponent},
  {path:'verification', component: VerificationPageComponent},
  {path:'suggestion', component: SuggestionPageComponent}
];

// https://angdev.ru/archive/angular9/angular-routing-guards/ Guards
// https://metanit.com/web/angular2/7.3.php Route Parameters
