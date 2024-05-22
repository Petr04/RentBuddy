import { Router } from '@angular/router';
import { AccountService } from './services/account.service'
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';

export const authGuardFn = ()=>{
  const auth = inject(AccountService)
  const router = inject(Router)
  return auth.isUserLoggedIn

}

// export const authorizedGuard: CanActivateFn = (route,) => {
//   return inject(AccountService);
// };
