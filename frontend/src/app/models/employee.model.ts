export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
}
export interface CreateEmployeeRequest {
  firstName: string;
  lastName: string;
}
export interface UpdateEmployeeRequest {
  id: number;
  firstName: string;
  lastName: string;
}
