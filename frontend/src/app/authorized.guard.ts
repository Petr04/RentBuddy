import { AccountService } from './services/account.service'
import { inject } from '@angular/core';

export const authGuardFn = ()=>{
  const auth = inject(AccountService)

  return auth.isUserLoggedIn

}

