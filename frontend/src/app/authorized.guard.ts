import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

export const authGuardFn = ()=>{
  const auth = inject(AuthService)
  const router = inject(Router)

  if ( auth.isAuthenticated()){
    return true
  }
  else{
    return router.parseUrl('/login')
  }
}

