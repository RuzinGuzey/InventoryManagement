import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {
  CreateInventoryGroupRequest,
  InventoryGroup,
  UpdateInventoryGroupRequest,
} from '../models/inventory-group.model';

const API_URL = `${environment.apiUrl}/api/inventoryGroups`;

@Injectable({
  providedIn: 'root',
})
export class InventoryGroupsService {
  constructor(private http: HttpClient) {}

  get(): Observable<Array<InventoryGroup>> {
    return this.http.get<Array<InventoryGroup>>(API_URL);
  }

  getById(id: number): Observable<InventoryGroup> {
    return this.http.get<InventoryGroup>(`${API_URL}/${id}`);
  }

  create(request: CreateInventoryGroupRequest): Observable<number> {
    return this.http.post<number>(API_URL, request);
  }

  update(id: number, request: UpdateInventoryGroupRequest): Observable<void> {
    return this.http.put<void>(`${API_URL}/${id}`, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}
