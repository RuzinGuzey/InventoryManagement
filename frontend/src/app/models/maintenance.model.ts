import { ProcessType } from './enums/process-type.enum';
import { Inventory } from './inventory.model';
import { VehicleInventory } from './vehicle-inventory.model';

export interface Maintenance {
  id: number;
  tecnicalServiceName: string;
  inventory: Inventory;
  vehicle: VehicleInventory;
  processType: ProcessType;
  operationDescription: string;
  price?: number;
  issuedOn: Date;
  dateDelivered?: Date;
}
export interface CreateMaintenanceRequest {
  tecnicalServiceName: string;
  inventory: Inventory;
  vehicle: VehicleInventory;
  processType: ProcessType;
  operationDescription: string;
  price?: number;
  issuedOn: Date;
  dateDelivered?: Date;
}
export interface UpdateMaintenanceRequest {
  id: number;
  tecnicalServiceName: string;
  inventory: Inventory;
  vehicle: VehicleInventory;
  processType: ProcessType;
  operationDescription: string;
  price?: number;
  issuedOn: Date;
  dateDelivered?: Date;
}
