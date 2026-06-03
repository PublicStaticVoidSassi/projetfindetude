import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Contacts } from '../../proxy';
import { LocalizationPipe } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import {ContactsourcePipe,ContactstatusPipe} from '../pipes';
import { NoteMiniform } from '../../notes/miniform/note-miniform.component';
import { NoteMiniUi } from '../../notes/note-mini-ui/note-mini-ui';
import { NoteDto, NotesService } from '../../proxy/notes';
@Component({
  standalone: true,
  imports: [
    ContactsourcePipe,
    ContactstatusPipe,
    ReturnBtn,
    LocalizationPipe,
    DatePipe,
    NoteMiniform,
    RouterLink,
    NoteMiniUi
  ],
  templateUrl: 'contact-details.html'
})
export class ContactDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private contactsService = inject(Contacts.ContactsService);
  notesService = inject(NotesService);
  notes :NoteDto[]= [];
  id: string = '';

  contact = {} as Contacts.ContactDto;

  constructor() {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.contactsService.get(this.id).subscribe(c => {
      this.contact = c;
      console.log(c);
    });
    this.notesService.getForContactByContactId(this.id).subscribe(e=>{
      this.notes = e;
    })
  }
}
