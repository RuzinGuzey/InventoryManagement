import { SegmentType } from './enums/segment-type.enum';

export interface VehicleInventory {
  id: number;
  marka: string;
  model: string;
  modelYear: number;
  sasiNo?: string;
  motorNo?: string;
  licencePlate: string;
  entryDate: Date;
  segment?: SegmentType;
}
export interface CreateVehicleInventoryRequest {
  marka: string;
  model: string;
  modelYear: number;
  sasiNo?: string;
  motorNo?: string;
  licencePlate: string;
  entryDate: Date;
  segment?: SegmentType;
}
export interface UpdateVehicleInventoryRequest {
  id: number;
  marka: string;
  model: string;
  modelYear: number;
  sasiNo?: string;
  motorNo?: string;
  licencePlate: string;
  entryDate: Date;
  segment?: SegmentType;
}
