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
      requiredPolicy: 'UniFlowCRM.Account',
      parentName: '::Menu:CRM:Objects'
    },
    {
      path: '/Leads',
      name: '::Menu:Leads',
      iconClass: 'fas fa-user',
      order: 20,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Lead',
      parentName: '::Menu:CRM:Objects'

    },
    {
      path: '/Contacts',
      name: '::Menu:Contacts',
      iconClass: 'fas fa-id-card',
      order: 30,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Contact',
      parentName: '::Menu:CRM:Objects'

    },
    {
      path: '/Opportunities',
      name: '::Menu:Opportunities',
      iconClass: 'fas fa-handshake',
      order: 40,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Opportunity',
      parentName: '::Menu:CRM:Sales'

    },
    {
      path: '/Calls',
      name: '::Menu:Calls',
      iconClass: 'fas fa-phone',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Call',
      parentName: "::Menu:CRM:Activities",
    },
    {
      path: '/Meetings',
      name: '::Menu:Meetings',
      iconClass: 'fas fa-users',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Meeting',
      parentName: "::Menu:CRM:Activities",
    },
    {
      path: '/Tasks',
      name: '::Menu:Tasks',
      iconClass: 'fas fa-random',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Task',
      parentName: "::Menu:CRM:Activities",
    },
    {
      path: '/Emails',
      name: '::Menu:Emails',
      iconClass: 'fas fa-envelope',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Email',
      order: 31,
      // parentName: "::Menu:CRM:Extras",
    },
    {
      // path: '/Analytics',
      name: '::Menu:Analytics',
      iconClass: 'fas fa-chart-pie',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.See',
      order: 32,
      // parentName: "::Menu:CRM:Extras",
    },
    {
      path: '/Analytics/Accounts',
      name: '::Menu:Analytics:Accounts',
      iconClass: 'fas fa-building',
      order: 10,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Account',
      parentName: '::Menu:Analytics'
    },
    {
      path: '/Analytics/Leads',
      name: '::Menu:Analytics:Leads',
      iconClass: 'fas fa-user',
      order: 20,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Lead',
      parentName: '::Menu:Analytics'

    },
    {
      path: '/Analytics/Contacts',
      name: '::Menu:Analytics:Contacts',
      iconClass: 'fas fa-id-card',
      order: 30,
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Contact',
      parentName: '::Menu:Analytics'

    },
    {
      path: '/Analytics/Opportunities',
      name: '::Menu:Analytics:Opportunities',
      iconClass: 'fas fa-handshake',
      layout: eLayoutType.application,
      requiredPolicy: 'UniFlowCRM.Opportunity',
      parentName: '::Menu:Analytics'

    },
    // {
    //   path: '/Notes',
    //   name: '::Menu:Notes',
    //   iconClass: 'fas fa-sticky-note',
    //   layout: eLayoutType.application,
    //   parentName: "::Menu:CRM:Extras",
    // },
    // {
    //     path: '/books',
    //     name: '::Menu:Books',
    //     iconClass: 'fas fa-book',
    //     layout: eLayoutType.application,
    //     requiredPolicy: 'UniFlowCRM.Books',
    //     parentName: "::Menu:CRM:Testing",
    // },
    //



    // big ones
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
      order: 2,
    },
    {
      name: "::Menu:CRM:Sales",
      iconClass: 'fas fa-usd',
      layout: eLayoutType.application,
      order: 3,
    },
    {
      name: "::Menu:CRM:Activities",
      iconClass: 'fas fa-list-ul',
      layout: eLayoutType.application,
      order: 4,
    },
    {
      name: "::Menu:CRM:Extras",
      iconClass: 'fas fa-star',
      layout: eLayoutType.application,
      order: 5
    }
  ]);
}
