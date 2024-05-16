import { Routes } from '@angular/router';
import { SelectRentComponent } from './select-rent/select-rent.component';
import { AboutUserComponent } from './about-user/about-user.component';
import { MatchPageComponent } from './match-page/match-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { authorizedGuard } from './authorized.guard';

export const routes: Routes = [
  {path:'select-rent', component:SelectRentComponent, canActivate: [authorizedGuard]},
  {path:'profile', component: AboutUserComponent, canActivate: [authorizedGuard]},
  {path:'match', component: MatchPageComponent, canActivate: [authorizedGuard]},
  {path:'registration', component: RegistrationPageComponent}
];

// https://angdev.ru/archive/angular9/angular-routing-guards/ Guards
// https://metanit.com/web/angular2/7.3.php Route Parameters
