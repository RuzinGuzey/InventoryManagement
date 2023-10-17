import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { InventoryRoutingModule } from './inventory-routing.module';

import { ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from '../../ng-zorro.antd.module';
import { InventoryComponent } from './inventory.component';
import { CreateComponent } from './pages/create/create.component';
import { ListComponent } from './pages/list/list.component';

@NgModule({
  declarations: [InventoryComponent, ListComponent, CreateComponent],
  imports: [
    CommonModule,
    InventoryRoutingModule,
    NgZorroAntdModule,
    ReactiveFormsModule,
  ],
})
export class InventoryModule {}
