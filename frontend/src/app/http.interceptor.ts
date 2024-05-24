import { HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError((err:any)=>{
      if (err.status == 0){
        console.error("Нет подключение к серверу")
      }
      return throwError(()=> err)
    }));
};
