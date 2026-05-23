import { Routes } from '@angular/router';
import { NotesComponent } from './notes';
import { NoteFormComponent } from './note-form.component';
// import {  } from './note-details.component';

export const NOTES_ROUTES: Routes = [
  {
    path: '',
    component: NotesComponent,
  },
  {
    path: 'form',
    component: NoteFormComponent,
  },
  {
    path: 'form/:id',
    component: NoteFormComponent,
  },
  // {
  //   path: ':id',
  //   component: NoteDetailsComponent,
  // },
];
