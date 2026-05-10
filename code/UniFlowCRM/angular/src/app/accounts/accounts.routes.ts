import { Routes } from '@angular/router';
import { AccountsComponent } from './accounts';
// import { AccountDetailsComponent } from './account-detail/account-detail';

export const ACCOUNTS_ROUTES: Routes = [
  {
    path: '',
    component: AccountsComponent,
  },
  {
    path: ':id',
    loadComponent: () =>
      import('./account-detail/account-detail')
        .then(c => c.AccountDetailsComponent),
  }
];
