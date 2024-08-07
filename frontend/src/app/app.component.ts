import { TuiRootModule, TuiDialogModule, TuiAlertModule } from "@taiga-ui/core";
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MatchPageComponent } from './match-page/match-page.component';
import { CommonModule } from '@angular/common';
import { SelectRentModule } from './select-rent-page/select-rent.module';
import { AuthenticationModule } from './authentication/authentication.module';
import { TestDetailComponent } from './test-route/test-route.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { ImageScrollerComponent } from "./app-image-scroller";
import { RenterProfileComponent } from "./renter-profile/renter-profile.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ImageScrollerComponent ,RouterOutlet, SelectRentModule, NotFoundPageComponent,TestDetailComponent, RenterProfileComponent, MatchPageComponent, AuthenticationModule, HttpClientModule, CommonModule, TuiRootModule, TuiDialogModule, TuiAlertModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {


}

