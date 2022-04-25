import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Appointment } from '../models/appointment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = `${environment.apiUrl}/appointments/book`;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private httpClient: HttpClient, private router: Router) { }

  book(model: any) {
    console.log(model);
    return this.httpClient.post(`${this.baseUrl}`, model).pipe(
      map((appointment: Appointment) => {
        if (appointment) {
        }
      })
    );
  }
}
