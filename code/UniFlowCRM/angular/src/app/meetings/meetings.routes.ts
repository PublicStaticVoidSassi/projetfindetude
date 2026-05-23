import { Routes } from '@angular/router';
import { Meetings } from './meetings';
import { MeetingFormComponent } from './meeting-form.component';
import { MeetingDetailsComponent } from './meeting-details.component';

export const MEETINGS_ROUTES: Routes = [
  {
    path: '',
    component: Meetings,
  },
  {
    path: 'form',
    component: MeetingFormComponent,
  },
  {
    path: 'form/:id',
    component: MeetingFormComponent,
  },
  {
    path: ':id',
    component: MeetingDetailsComponent,
  },
];