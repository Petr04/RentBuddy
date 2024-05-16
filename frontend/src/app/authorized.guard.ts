import { CanActivateFn } from '@angular/router';

export const authorizedGuard: CanActivateFn = () => {
  return true;
};
