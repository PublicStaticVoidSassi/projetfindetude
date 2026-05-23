import { Routes } from '@angular/router';
import { EmailsComponent } from './emails.component';
import { EmailFormComponent } from './email-form/email-form.component';
import { EmailDetailsComponent } from './email-details/email-details.component';

export const EMAILS_ROUTES: Routes = [
  {
    path: '',
    component: EmailsComponent,
  },
  {
    path: 'form',
    component: EmailFormComponent,
  },
  {
    path: 'form/:id',
    component: EmailFormComponent,
  },
  {
    path: ':id',
    component: EmailDetailsComponent,
  },
];