import { Routes } from '@angular/router';
import { CallsComponent } from './calls';
import { CallFormComponent } from './call-form/call-form.component';
import { CallDetailsComponent } from './call-details/call-details.component';

export const CALLS_ROUTES: Routes = [
  {
    path: '',
    component: CallsComponent,
  },
  {
    path: 'form',
    component: CallFormComponent,
  },
  {
    path: 'form/:id',
    component: CallFormComponent,
  },
  {
    path: ':id',
    component: CallDetailsComponent,
  },
];