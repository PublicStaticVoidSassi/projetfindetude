import { Routes } from '@angular/router';
import {AnalyticsComponent as contacts} from './contacts/analytics';
import {AnalyticsComponent as accounts} from './accounts/analytics';
import {AnalyticsComponent as opportunities} from './opportunities/analytics';
import {AnalyticsComponent as leads} from './leads/analytics';
export const ROUTES: Routes = [
  {
    path: 'Leads',
    component: leads,
  },
  {
    path: 'Contacts',
    component: contacts,
  },
  {
    path: 'Accounts',
    component: accounts,
  },
  {
    path: 'Opportunities' ,
    component: opportunities,
  },
];
