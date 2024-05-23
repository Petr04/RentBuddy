import { ErrorHandler, Injectable } from '@angular/core';

@Injectable()

export class GlobalErrorHandlerService implements ErrorHandler {

  constructor() { }

  handleError(error: Error): void{
    console.error('Global Error Handler:', error)
  }

}
