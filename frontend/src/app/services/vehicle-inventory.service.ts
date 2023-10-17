import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateVehicleInventoryRequest,
  UpdateVehicleInventoryRequest,
  VehicleInventory,
} from '../models/vehicle-inventory.model';

const API_URL = `${environment.apiUrl}/api/vehicleInventories`;

@Injectable({
  providedIn: 'root',
})
export class VehicleInventoryService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<VehicleInventory>> {
    return this.http.get<Array<VehicleInventory>>(API_URL);
  }

  getById(id: number): Observable<VehicleInventory> {
    return this.http.get<VehicleInventory>(`${API_URL}/${id}`);
  }

  create(request: CreateVehicleInventoryRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateVehicleInventoryRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
