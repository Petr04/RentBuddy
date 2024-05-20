import { CanActivateFn } from '@angular/router';
import { AccountService } from './services/account.service'
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class authorizedGuardService {}

export const authorizedGuard: CanActivateFn = () => {
  return inject(AccountService).isUserLoggedIn;
};
