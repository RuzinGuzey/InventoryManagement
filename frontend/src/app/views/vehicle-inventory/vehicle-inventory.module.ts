import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VehicleInventoryRoutingModule } from './vehicle-inventory-routing.module';
import { VehicleInventoryComponent } from './vehicle-inventory.component';
import { VehicleInventoryListComponent } from './pages/vehicle-inventory-list/vehicle-inventory-list.component';
import { VehicleInventoryCreateComponent } from './pages/vehicle-inventory-create/vehicle-inventory-create.component';


@NgModule({
  declarations: [
    VehicleInventoryComponent,
    VehicleInventoryListComponent,
    VehicleInventoryCreateComponent
  ],
  imports: [
    CommonModule,
    VehicleInventoryRoutingModule
  ]
})
export class VehicleInventoryModule { }
