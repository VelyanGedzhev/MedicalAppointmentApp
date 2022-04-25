import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentRoutingModule } from './appointments-routing.module';
import { DatepickerComponent } from './datepicker/datepicker.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    BookAppointmentComponent,
    AppointmentsListComponent,
    AppointmentDetailsComponent,
    DatepickerComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ]
})
export class AppointmentsModule { }
