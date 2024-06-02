import { provideAnimations } from "@angular/platform-browser/animations";
import { TuiRootModule } from "@taiga-ui/core";
import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async'
import { httpInterceptor } from './http.interceptor';
import { GlobalErrorHandlerService } from './services/global-error-handler.service';

export const appConfig: ApplicationConfig = {
<<<<<<< Updated upstream
  providers: [provideAnimations(), provideRouter(routes), provideClientHydration(), GlobalErrorHandlerService, HttpClientModule,importProvidersFrom(HttpClientModule, TuiRootModule) , provideAnimationsAsync(),
=======
  providers: [provideRouter(routes), provideClientHydration(), GlobalErrorHandlerService,
    HttpClientModule,importProvidersFrom(HttpClientModule) , provideAnimationsAsync(),
>>>>>>> Stashed changes
    provideHttpClient(withInterceptors([httpInterceptor]))
  ]
};
