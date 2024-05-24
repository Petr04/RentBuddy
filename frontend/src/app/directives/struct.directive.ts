import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appStruct]',
  standalone: true
})
export class StructDirective {

  constructor(private templateRef: TemplateRef<any>, private viewContainer: ViewContainerRef) { }

  @Input()
  public set appStruct(condition: boolean){
    console.log()
  }
}



