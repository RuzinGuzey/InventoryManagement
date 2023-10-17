import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
  },
  {
    name: 'Envanter',
    url: '/inventory',
    iconComponent: { name: 'cil-circle' },
    children: [
      {
        name: 'Envanter Listesi',
        url: '/inventory/list',
      },
      {
        name: 'Envanter Grubu',
        url: '/inventory/groups',
      },
    ],
  },
  {
    name: 'İletişim Hizmetleri',
    url: '/communications',
    iconComponent: { name: 'cil-circle' },
  },
  {
    name: 'Araç Envanteri',
    url: '/vehicle-inventory',
    iconComponent: { name: 'cil-circle' },
  },
];
