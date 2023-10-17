import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateInsuranceRequest,
  Insurance,
  UpdateInsuranceRequest,
} from '../models/insurance.model';

const API_URL = `${environment.apiUrl}/api/insurances`;

@Injectable({
  providedIn: 'root',
})
export class InsurancesService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<Insurance>> {
    return this.http.get<Array<Insurance>>(API_URL);
  }

  getById(id: number): Observable<Insurance> {
    return this.http.get<Insurance>(`${API_URL}/${id}`);
  }

  create(request: CreateInsuranceRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateInsuranceRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
