import { ApplicationConfig, ErrorHandler, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async'
import { httpInterceptor } from './http.interceptor';
import { GlobalErrorHandlerService } from './services/global-error-handler.service';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideClientHydration(), {provide:ErrorHandler, useClass:GlobalErrorHandlerService}, HttpClientModule,importProvidersFrom(HttpClientModule) , provideAnimationsAsync(),
    provideHttpClient(withInterceptors([httpInterceptor]))
  ]
};
