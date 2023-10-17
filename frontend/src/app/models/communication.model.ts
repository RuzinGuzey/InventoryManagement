import { RateCardType } from './enums/rate-card-type.enum';
import { ServiceType } from './enums/service-type.enum';

export interface Communication {
  id: number;
  serviceType: ServiceType;
  employeeId?: number;
  serviceNumber: string;
  rate: RateCardType;
  operatorId: number;
  protocolName?: string;
  price: number;
  startTime?: Date;
  endTime?: Date;
}
export interface CreateCommunicationRequest {
  serviceType: ServiceType;
  employeeId?: number;
  serviceNumber: string;
  rate: RateCardType;
  operatorId: number;
  protocolName?: string;
  price: number;
  startTime?: Date;
  endTime?: Date;
}
export interface UpdateCommunicationRequest {
  id: number;
  serviceType: ServiceType;
  employeeId?: number;
  serviceNumber: string;
  rate: RateCardType;
  operatorId: number;
  protocolName?: string;
  price: number;
  startTime?: Date;
  endTime?: Date;
}
