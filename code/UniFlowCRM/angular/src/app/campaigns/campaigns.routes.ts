import { Routes } from '@angular/router';
import { AccountsComponent } from '../accounts/accounts';
import { AccountFormComponent } from '../accounts/account-form/account-form';
import {Campaigns} from './campaigns';
import {Form} from './form/form';
import {Details} from './details/details';

export const ROUTES: Routes = [
  {
    path: '',
    component: Campaigns,
  },
  {
    path: 'form',
    component: Form
  },
  // {
  //   path: 'form/:id',
  //   loadComponent: () =>
  //     import('../accounts/account-form/account-form')
  //       .then(c => c.AccountFormComponent),
  // },
  {
    path: ':id',
    component: Details,
  },

];
