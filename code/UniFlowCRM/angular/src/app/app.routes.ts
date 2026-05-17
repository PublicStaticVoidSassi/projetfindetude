import { authGuard, permissionGuard } from '@abp/ng.core';
import { Routes } from '@angular/router';

export const APP_ROUTES: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadComponent: () => import('./home/home.component').then(c => c.HomeComponent),
  },
  {
    path: 'Accounts',
    loadChildren: () =>
      import('./accounts/accounts.routes')
        .then(r => r.ACCOUNTS_ROUTES),
    canActivate: [authGuard, permissionGuard]
  },
  {
    path: 'Leads',
    loadChildren: () =>
      import('./leads/leads.routes')
        .then(r => r.LEADS_ROUTES),
    canActivate: [authGuard, permissionGuard]
  },
  {
    path: 'Contacts',
    loadChildren: () =>
      import('./contacts/contacts.routes')
        .then(r => r.CONTACTS_ROUTES),
    canActivate: [authGuard, permissionGuard]
  },
  {
    path: 'Opportunities',
    loadChildren: () =>
      import('./opportunities/opportunities.routes')
        .then(r => r.OPPORTUNITIES_ROUTES),
    canActivate: [authGuard, permissionGuard]
  },
    {
    path: 'Notes',
    loadChildren: () =>
      import('./notes/notes.routes')
        .then(r => r.NOTES_ROUTES),
    canActivate: [authGuard, permissionGuard]
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(c => c.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(c => c.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () => import('@abp/ng.setting-management').then(c => c.createRoutes()),
  },
  {
    path: 'books',
    loadComponent: () => import('./book/book.component').then(c => c.BookComponent),
    canActivate: [authGuard, permissionGuard],
  },
];
