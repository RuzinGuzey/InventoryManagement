import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommunicationComponent } from './communication.component';
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
    component: CommunicationComponent,
    children: [
      {
        path: 'list',
        component: ListComponent,
        data: {
          title: 'İletişim Hizmetleri',
        },
      },
      {
        path: 'new',
        component: CreateComponent,
        data: {
          title: 'Yeni Anlaşma',
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CommunicationRoutingModule {}
