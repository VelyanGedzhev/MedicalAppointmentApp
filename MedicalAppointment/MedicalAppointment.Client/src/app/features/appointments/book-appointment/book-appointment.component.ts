import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Appointment } from 'src/app/core/models/appointment';
import { AppointmentService } from 'src/app/core/services/appointment.service';

@Component({
  selector: 'app-book-appointment',
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.css']
})
export class BookAppointmentComponent implements OnInit {
  appointment: Appointment;
  bookForm: FormGroup;
  bsValue = new Date();
  maxDate = new Date();
  minDate = new Date();

  constructor(private appointmentService: AppointmentService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.minDate.setDate(this.minDate.getDate() - 1);
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.initializeForm();
  }

  initializeForm() {
    this.bookForm = new FormGroup({
      date: new FormControl,
    });
  }

  book() {
    const app: Appointment = {
      appUserId: JSON.parse(localStorage.getItem('user')).id,
      date: this.bookForm.value.date,
      physicianId: Number(this.route.snapshot.paramMap.get('id')),
      physicianName: ''
    };

    this.appointmentService.book(app).subscribe(response => {
    });
  }
}
