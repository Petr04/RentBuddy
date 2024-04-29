import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sort-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sort-bar.component.html',
  styleUrl: './sort-bar.component.css'
})
export class SortBarComponent {
  public isOpen: boolean = false;
}
