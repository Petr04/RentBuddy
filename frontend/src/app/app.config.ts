import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { PostService } from './requests/services/post/post.service';
import { HttpClientModule } from '@angular/common/http';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async'
import { AccountService } from './requests/services/account/account.service';
// import { authorizedGuardService } from './authorized.guard';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideClientHydration(), importProvidersFrom(HttpClientModule),AccountService, PostService,  provideAnimationsAsync()]
};
