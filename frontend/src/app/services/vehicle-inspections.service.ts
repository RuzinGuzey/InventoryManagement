import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateVehicleInspectionRequest,
  UpdateVehicleInspectionRequest,
  VehicleInspection,
} from '../models/vehicle-inspection.model';

const API_URL = `${environment.apiUrl}/api/vehicleInspections`;

@Injectable({
  providedIn: 'root',
})
export class VehicleInspectionsService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<VehicleInspection>> {
    return this.http.get<Array<VehicleInspection>>(API_URL);
  }

  getById(id: number): Observable<VehicleInspection> {
    return this.http.get<VehicleInspection>(`${API_URL}/${id}`);
  }

  create(request: CreateVehicleInspectionRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(
    id: number,
    request: UpdateVehicleInspectionRequest
  ): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
