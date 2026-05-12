import { Routes } from '@angular/router';
import { LeadsComponent } from './leads';
import { LeadDetailsComponent } from './lead-details/lead-details';
import { LeadFormComponent } from './lead-form/lead-form';
// import { AccountsComponent } from './accounts';
// import { AccountFormComponent } from './account-form/account-form';
// import { AccountDetailsComponent } from './account-detail/account-detail';
// import { Component } from '@angular/core';

export const LEADS_ROUTES: Routes = [
  {
    path: '',
    component: LeadsComponent,
  },
  {
    path: 'form',
    component: LeadFormComponent
  },
  {
    path: 'form/:id',
    component: LeadFormComponent
  },
  {
    path: ':id',
    component: LeadDetailsComponent,
  },
  
];
