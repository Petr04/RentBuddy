import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectRentComponent } from './select-rent/select-rent.component';
import { SortBarComponent } from '../components/sort-bar/sort-bar.component';
import { BigCardComponent } from '../components/big-card/big-card.component';
import { FilterPipe } from '../pipes/filter.pipe';
import { NextBtnComponent } from '../components/next-btn/next-btn.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ImageScrollerComponent } from '../app-image-scroller';
import { FilterRentsComponent } from '../filter-rents/filter-rents.component';

const routes:Routes = [
  {path: '', component: SelectRentComponent}
]

@NgModule({
  declarations: [SelectRentComponent, SortBarComponent],
  imports: [
    CommonModule,
    BigCardComponent,
    FilterPipe,
    NextBtnComponent,
    ReactiveFormsModule,
    FormsModule,
    ImageScrollerComponent,
    RouterModule.forChild(routes),
    FilterRentsComponent
  ],
})
export class SelectRentModule { }
