import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Appointment } from '../models/appointment';
import { AppointmentDetails } from '../models/appointmentDetails';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = `${environment.apiUrl}/appointments`;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private httpClient: HttpClient, private router: Router) { }

  getAppointments(id: number): Observable<AppointmentDetails[]> {
    return this.httpClient.get<AppointmentDetails[]>(`${this.baseUrl}/${id}`);
  }

  book(model: any) {
    console.log(model);
    return this.httpClient.post(`${this.baseUrl}/book`, model).pipe(
      map((appointment: Appointment) => {
        if (appointment) {
        }
      })
    );
  }
}
