import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateInventoryRequest,
  Inventory,
  UpdateInventoryRequest,
} from '../models/inventory.model';

const API_URL = `${environment.apiUrl}/api/inventories`;

@Injectable({
  providedIn: 'root',
})
export class InventoriesService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<Inventory>> {
    return this.http.get<Array<Inventory>>(API_URL);
  }

  getById(id: number): Observable<Inventory> {
    return this.http.get<Inventory>(`${API_URL}/${id}`);
  }

  create(request: CreateInventoryRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateInventoryRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
