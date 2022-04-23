import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentRoutingModule } from './appointments-routing.module';



@NgModule({
  declarations: [
    BookAppointmentComponent,
    AppointmentsListComponent,
    AppointmentDetailsComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule
  ]
})
export class AppointmentsModule { }
