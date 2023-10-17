export interface Debit {
  id: number;
  employeeId: number;
  inventoryId: number;
  startDate: Date;
  returnDate?: Date;
  note?: string;
}
export interface CreateDebitRequest {
  employeeId: number;
  inventoryId: number;
  startDate: Date;
  returnDate?: Date;
  note?: string;
}
export interface UpdateDebitRequest {
  id: number;
  employeeId: number;
  inventoryId: number;
  startDate: Date;
  returnDate?: Date;
  note?: string;
}
