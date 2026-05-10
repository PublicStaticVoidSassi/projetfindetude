import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
    {
      path: '/Accounts',
      name: '::Menu:Accounts',
      iconClass: 'fas fa-building',
      order: 10,
      layout: eLayoutType.application,
      parentName: '::Menu:CRM:Objects'
    },
    {
      path: '/Leads',
      name: '::Menu:Leads',
      iconClass: 'fas fa-user',
      order: 20,
      layout: eLayoutType.application,
      parentName: '::Menu:CRM:Objects'

    },
    {
      path: '/Contacts',
      name: '::Menu:Contacts',
      iconClass: 'fas fa-id-card',
      order: 30,
      layout: eLayoutType.application,
      parentName: '::Menu:CRM:Objects'

    },
    {
      path: '/Opportunities',
      name: '::Menu:Opportunities',
      iconClass: 'fas fa-dollar',
      order: 40,
      layout: eLayoutType.application,
      parentName: '::Menu:CRM:Objects'

    },
    {
        path: '/books',
        name: '::Menu:Books',
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        requiredPolicy: 'UniFlowCRM.Books',
        parentName: "::Menu:CRM:Testing",
    },
    {
      name: "::Menu:CRM:Testing",
      iconClass: 'fas fa-paper',
      layout: eLayoutType.application,
      order: 102,
    },
    {
      name: "::Menu:CRM:Objects",
      iconClass: 'fas fa-address-book',
      layout: eLayoutType.application,
      order: 100,
    },
    {
      name: "::Menu:CRM:Activities",
      iconClass: 'fas fa-layer-book',
      layout: eLayoutType.application,
      order: 101,
    }
  ]);
}
