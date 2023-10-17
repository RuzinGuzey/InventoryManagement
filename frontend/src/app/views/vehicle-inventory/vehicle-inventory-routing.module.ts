import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleInventoryComponent } from './vehicle-inventory.component';
import { VehicleInventoryListComponent } from './pages/vehicle-inventory-list/vehicle-inventory-list.component';
import { VehicleInventoryCreateComponent } from './pages/vehicle-inventory-create/vehicle-inventory-create.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: '',
    component: VehicleInventoryListComponent,
    children: [
      {
        path: 'list',
        component: VehicleInventoryListComponent,
        data: {
          title: 'Araç Envanter Listesi',
        },
      },
      {
        path: 'new',
        component: VehicleInventoryCreateComponent,
        data: {
          title: 'Yeni Araç Envanteri',
        },
      },
      {
        path: 'edit/:id',
        component: VehicleInventoryCreateComponent,
        data: {
          title: 'Araç Envanterini Düzenle',
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleInventoryRoutingModule { }
