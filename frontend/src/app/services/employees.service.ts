import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateEmployeeRequest,
  Employee,
  UpdateEmployeeRequest,
} from '../models/employee.model';

const API_URL = `${environment.apiUrl}/api/employees`;

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(API_URL);
  }

  getById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${API_URL}/${id}`);
  }

  create(request: CreateEmployeeRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateEmployeeRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
