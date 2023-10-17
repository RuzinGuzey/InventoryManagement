import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateDebitRequest,
  Debit,
  UpdateDebitRequest,
} from '../models/debit.model';

const API_URL = `${environment.apiUrl}/api/debits`;

@Injectable({
  providedIn: 'root',
})
export class DebitsService {
  constructor(private http: HttpClient) {}
  get(): Observable<Array<Debit>> {
    return this.http.get<Array<Debit>>(API_URL);
  }

  getById(id: number): Observable<Debit> {
    return this.http.get<Debit>(`${API_URL}/${id}`);
  }

  create(request: CreateDebitRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateDebitRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
