import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhysiciansListComponent } from './physicians-list/physicians-list.component';
import { PhysicianDetailsComponent } from './physician-details/physician-details.component';
import { PhysiciansRoutingModule } from './physicians-routing.module';



@NgModule({
  declarations: [
    PhysiciansListComponent,
    PhysicianDetailsComponent,
  ],
  imports: [
    CommonModule,
    PhysiciansRoutingModule
  ]
})
export class PhysiciansModule { }
