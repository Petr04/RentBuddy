import { Component } from '@angular/core';

@Component({
  selector: 'app-bi-select',
  standalone: true,
  imports: [],
  templateUrl: './bi-select.component.html',
  styleUrl: './bi-select.component.css'
})
export class BiSelectComponent {
  public male(){
    document.getElementById('male')!.classList.remove('opacity-40');
    document.getElementById('female')!.classList.add('opacity-40');
  }
  public female(){
    document.getElementById('male')!.classList.add('opacity-40');
    document.getElementById('female')!.classList.remove('opacity-40');
  }
  public smoke(){
    document.getElementById('smoke')!.classList.remove('opacity-40');
    document.getElementById('noSmoke')!.classList.add('opacity-40');
  }
  public noSmoke(){
    document.getElementById('smoke')!.classList.add('opacity-40');
    document.getElementById('noSmoke')!.classList.remove('opacity-40');
  }
  public pet(){
    document.getElementById('pet')!.classList.remove('opacity-40');
    document.getElementById('noPet')!.classList.add('opacity-40');
  }
  public noPet(){
    document.getElementById('pet')!.classList.add('opacity-40');
    document.getElementById('noPet')!.classList.remove('opacity-40');
  }
}
