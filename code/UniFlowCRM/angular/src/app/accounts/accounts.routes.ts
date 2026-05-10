import { Routes } from '@angular/router';
import { AccountsComponent } from './accounts';
import { AccountFormComponent } from './account-form/account-form';
// import { AccountDetailsComponent } from './account-detail/account-detail';
import { Component } from '@angular/core';

export const ACCOUNTS_ROUTES: Routes = [
  {
    path: '',
    component: AccountsComponent,
  },
  {
    path: 'form',
    component: AccountFormComponent
  },
  {
    path: 'form/:id',
    loadComponent: () =>
      import('./account-form/account-form')
        .then(c => c.AccountFormComponent),
  },
  {
    path: ':id',
    loadComponent: () =>
      import('./account-detail/account-detail')
        .then(c => c.AccountDetailsComponent),
  },
  
];
