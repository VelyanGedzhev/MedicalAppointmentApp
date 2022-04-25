import { Component, Input, OnInit } from '@angular/core';
import { Appointment } from 'src/app/core/models/appointment';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})
export class AppointmentDetailsComponent implements OnInit {
  
  @Input() appointment: Appointment;
  
  constructor() { }

  ngOnInit(): void {
  }

}
