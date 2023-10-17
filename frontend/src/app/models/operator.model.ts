export interface Operator {
  id: number;
  name: string;
}
export interface CreateOperatorRequest {
  name: string;
}
export interface UpdateOperatorRequest {
  id: number;
  name: string;
}
