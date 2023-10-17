import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateOperatorRequest,
  Operator,
  UpdateOperatorRequest,
} from '../models/operator.model';

const API_URL = `${environment.apiUrl}/api/operators`;

@Injectable({
  providedIn: 'root',
})
export class OperatorsService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<Operator>> {
    return this.http.get<Array<Operator>>(API_URL);
  }

  getById(id: number): Observable<Operator> {
    return this.http.get<Operator>(`${API_URL}/${id}`);
  }

  create(request: CreateOperatorRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateOperatorRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
