import { Routes } from '@angular/router';
import { OpportunitiesComponent } from './opportunities';
import {OpportunityDetailsComponent} from './opportunity-details/opportunity-details'
import {OpportunityFormComponent} from './opportunity-form/opportunity-form'
// import { LeadDetailsComponent } from './lead-details/lead-details';
// import { LeadFormComponent } from './lead-form/lead-form';
// import { AccountsComponent } from './accounts';
// import { AccountFormComponent } from './account-form/account-form';
// import { AccountDetailsComponent } from './account-detail/account-detail';
// import { Component } from '@angular/core';

export const OPPORTUNITIES_ROUTES: Routes = [
  {
    path: '',
    component: OpportunitiesComponent,
  },
  {
    path: 'form',
    component: OpportunityFormComponent
  },
  {
    path: 'form/:id',
    component: OpportunityFormComponent
  },
  {
    path: ':id',
    component: OpportunityDetailsComponent,
  },

];
