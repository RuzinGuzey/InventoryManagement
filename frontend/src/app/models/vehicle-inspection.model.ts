export interface VehicleInspection {
  id: number;
  technicalServiceName: string;
  vehicleInventoryId: string;
  sasiNo: string;
  motorNo: string;
  licencePlate: string;
  inspectionDate: Date;
  inspectionResult?: string;
  expiryDate: Date;
}
export interface CreateVehicleInspectionRequest {
  technicalServiceName: string;
  vehicleInventoryId: string;
  sasiNo: string;
  motorNo: string;
  licencePlate: string;
  inspectionDate: Date;
  inspectionResult?: string;
  expiryDate: Date;
}
export interface UpdateVehicleInspectionRequest {
  id: number;
  technicalServiceName: string;
  vehicleInventoryId: string;
  sasiNo: string;
  motorNo: string;
  licencePlate: string;
  inspectionDate: Date;
  inspectionResult?: string;
  expiryDate: Date;
}
