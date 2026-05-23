import { Routes } from '@angular/router';
import { Tasks } from './tasks';
import { TaskFormComponent } from './task-form.component';
import { TaskDetailsComponent } from './task-details.component';

export const TASKS_ROUTES: Routes = [
  {
    path: '',
    component: Tasks,
  },
  {
    path: 'form',
    component: TaskFormComponent,
  },
  {
    path: 'form/:id',
    component: TaskFormComponent,
  },
  {
    path: ':id',
    component: TaskDetailsComponent,
  },
];
