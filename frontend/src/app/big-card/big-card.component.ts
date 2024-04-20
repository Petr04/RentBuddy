import { Component, Input } from '@angular/core';
import { Dwelling } from '../app.component';

@Component({
  selector: 'app-big-card',
  standalone: true,
  imports: [],
  templateUrl: './big-card.component.html',
  styleUrl: './big-card.component.css'
})
export class BigCardComponent {
  @Input()
  public dwelling! : Dwelling;
}
