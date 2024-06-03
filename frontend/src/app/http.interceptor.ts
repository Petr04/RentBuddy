import { HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError((err: {status: number})=>{
      if (err.status == 0){
        alert("Нет подключения к интернету")
      }
      return throwError(()=> err)
    }));
};
