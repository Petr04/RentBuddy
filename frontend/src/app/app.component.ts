import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SortBarComponent } from './sort-bar/sort-bar.component';
import { BigCardComponent } from './big-card/big-card.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SortBarComponent,  BigCardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'rent-buddy';
}
