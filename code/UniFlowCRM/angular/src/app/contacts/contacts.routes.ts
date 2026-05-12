import { Routes } from '@angular/router';
import { ContactsComponent } from './contacts';
import { ContactDetailsComponent } from './contact-details/contact-details';
import { ContactFormComponent } from './contact-form/contact-form';
// import { AccountsComponent } from './accounts';
// import { AccountFormComponent } from './account-form/account-form';
// import { AccountDetailsComponent } from './account-detail/account-detail';
// import { Component } from '@angular/core';

export const CONTACTS_ROUTES: Routes = [
  {
    path: '',
    component: ContactsComponent,
  },
  {
    path: 'form',
    component: ContactFormComponent
  },
  {
    path: 'form/:id',
    component: ContactFormComponent
  },
  {
    path: ':id',
    component: ContactDetailsComponent,
  },
  
];
