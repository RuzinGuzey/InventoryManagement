import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateMaintenanceRequest,
  Maintenance,
  UpdateMaintenanceRequest,
} from '../models/maintenance.model';

const API_URL = `${environment.apiUrl}/api/maintenances`;

@Injectable({
  providedIn: 'root',
})
export class MaintenancesService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<Maintenance>> {
    return this.http.get<Array<Maintenance>>(API_URL);
  }

  getById(id: number): Observable<Maintenance> {
    return this.http.get<Maintenance>(`${API_URL}/${id}`);
  }

  create(request: CreateMaintenanceRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateMaintenanceRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
