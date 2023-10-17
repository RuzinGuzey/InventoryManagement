import { InsuranceType } from './enums/insurance-type.enum';

export interface Insurance {
  id: number;
  insuranceType: InsuranceType;
  vehicleInventoryId: number;
  licencePlate: string;
  firstInsuranceDtae: Date;
  attachmentDate: Date;
  deadLineDate: Date;
  insuranceAmount: number;
}
export interface CreateInsuranceRequest {
  insuranceType: InsuranceType;
  licencePlate: string;
  firstInsuranceDate: Date;
  attachmentDate: Date;
  deadLinedate: Date;
  insuranceAmount: number;
}
export interface UpdateInsuranceRequest {
  id: number;
  insuranceType: InsuranceType;
  vehicleInventoryId: number;
  licencePlate: string;
  firstInsuranceDate: Date;
  attachmentDate: Date;
  deadLinedate: Date;
  insuranceAmount: number;
}
