export interface Inventory {
  id: number;
  marka: string;
  model: string;
  seriNo: string;
  inventoryGroupId: number;
  entryDate: Date;
  guaranteeStart?: Date;
  guaranteeEnd?: Date;
  price?: number;
  whereAbout: string;
}

export interface CreateInventoryRequest {
  marka: string;
  model: string;
  seriNo: string;
  inventoryGroupId: number;
  entryDate: Date;
  guaranteeStart?: Date;
  guaranteeEnd?: Date;
  price?: number;
  whereAbout: string;
}

export interface UpdateInventoryRequest{
    id: number;
    marka: string;
    model: string;
    seriNo: string;
    inventoryGroupId: number;
    entryDate: Date;
    guaranteeStart?: Date;
    guaranteeEnd?: Date;
    price?: number;
    whereAbout: string;
}
