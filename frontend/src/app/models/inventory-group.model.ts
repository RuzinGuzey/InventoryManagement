export interface InventoryGroup {
  id: number;
  parentId?: number;
  name: string;
}
export interface CreateInventoryGroupRequest {
  parentId?: number;
  name: string;
}
export interface UpdateInventoryGroupRequest {
  id: number;
  parentId?: number;
  name: string;
}
