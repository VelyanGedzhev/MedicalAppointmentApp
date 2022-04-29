import { Component, Input, OnInit } from '@angular/core';
import { AppointmentDetails } from 'src/app/core/models/appointmentDetails';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})
export class AppointmentDetailsComponent implements OnInit {
  
  @Input() appointment: AppointmentDetails;
  
  constructor() { }

  ngOnInit(): void {
  }

}
