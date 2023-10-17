import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventoryComponent } from './inventory.component';
import { CreateComponent } from './pages/create/create.component';
import { ListComponent } from './pages/list/list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: '',
    component: InventoryComponent,
    children: [
      {
        path: 'list',
        component: ListComponent,
        data: {
          title: 'Envanter Listesi',
        },
      },
      {
        path: 'new',
        component: CreateComponent,
        data: {
          title: 'Yeni Envanter',
        },
      },
      {
        path: 'edit/:id',
        component: CreateComponent,
        data: {
          title: 'Envanter Düzenle',
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InventoryRoutingModule {}
