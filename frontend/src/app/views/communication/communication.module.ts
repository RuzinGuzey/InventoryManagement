import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NgZorroAntdModule } from 'src/app/ng-zorro.antd.module';
import { CommunicationRoutingModule } from './communication-routing.module';
import { CommunicationComponent } from './communication.component';
import { CreateComponent } from './pages/create/create.component';
import { ListComponent } from './pages/list/list.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [CommunicationComponent, CreateComponent, ListComponent],
  imports: [CommonModule, CommunicationRoutingModule, NgZorroAntdModule, ReactiveFormsModule],
})
export class CommunicationModule {}
