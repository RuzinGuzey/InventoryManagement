import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  Communication,
  CreateCommunicationRequest,
  UpdateCommunicationRequest,
} from '../models/communication.model';

const API_URL = `${environment.apiUrl}/api/communications`;

@Injectable({
  providedIn: 'root',
})
export class CommunicationsService {
  constructor(private http: HttpClient) {}
  get(): Observable<Array<Communication>> {
    return this.http.get<Array<Communication>>(API_URL);
  }

  getById(id: number): Observable<Communication> {
    return this.http.get<Communication>(`${API_URL}/${id}`);
  }

  create(request: CreateCommunicationRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateCommunicationRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
