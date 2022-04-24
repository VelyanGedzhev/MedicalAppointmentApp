import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhysiciansListComponent } from './physicians-list/physicians-list.component';
import { PhysicianDetailsComponent } from './physician-details/physician-details.component';
import { PhysiciansRoutingModule } from './physicians-routing.module';
import { PhysicianCardComponent } from './physician-card/physician-card.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    PhysiciansListComponent,
    PhysicianDetailsComponent,
    PhysicianCardComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    PhysiciansRoutingModule
  ]
})
export class PhysiciansModule { }
