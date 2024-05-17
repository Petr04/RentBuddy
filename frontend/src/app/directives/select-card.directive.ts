import {AfterViewInit, Directive, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[SelectCard]',
  standalone: true
})
export class SelectCardDirective implements AfterViewInit  {

  @HostBinding('class.directive') directive: boolean = false
  @HostListener('click') handler(){
    this.directive = !this.directive
  }
  constructor() {

  }

  ngAfterViewInit(): void {

  }
}
