import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/core/models/appointment';
import { AppointmentDetails } from 'src/app/core/models/appointmentDetails';
import { AppointmentService } from 'src/app/core/services/appointment.service';

@Component({
  selector: 'app-appointments-list',
  templateUrl: './appointments-list.component.html',
  styleUrls: ['./appointments-list.component.css']
})
export class AppointmentsListComponent implements OnInit {
  appointments: AppointmentDetails[];

  constructor(private appointmentService: AppointmentService) { }

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments() {
    const id = JSON.parse(localStorage.getItem('user')).id;
    this.appointmentService.getAppointments(id).subscribe(appointments => {
      this.appointments = appointments;
    });
  }
}
