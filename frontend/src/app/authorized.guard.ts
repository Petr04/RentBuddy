import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';

export const authGuardFn = ()=>{
  const auth = inject(AuthService)
  console.log(auth.isAuthenticated())
  return auth.isAuthenticated()

}

