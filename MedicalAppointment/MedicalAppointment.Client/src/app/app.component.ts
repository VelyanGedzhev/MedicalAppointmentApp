import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const apiUrl = environment.apiUrl;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'MedicalAppointment.Client';
  users: any;

  constructor(private httpClient: HttpClient) {

  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    console.log("get users")
     this.httpClient.get(`${apiUrl}/users`).subscribe(users => {
      this.users = users;
    });
  }
}
