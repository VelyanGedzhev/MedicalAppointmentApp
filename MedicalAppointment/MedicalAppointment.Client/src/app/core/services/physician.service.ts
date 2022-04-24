import { HttpClient, HttpHeaders, HttpParamsOptions } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Physician } from '../models/physician';

@Injectable({
  providedIn: 'root'
})
export class PhysicianService {
  baseUrl = `${environment.apiUrl}/physicians`;
  
  constructor(private httpClient: HttpClient) { }

  getPhysicians(): Observable<Physician[]> {
    return this.httpClient.get<Physician[]>(`${this.baseUrl}`);
  }

  getPhysician(name: string): Observable<Physician> {
    return this.httpClient.get<Physician>(`${this.baseUrl}/${name}`);
  }
}