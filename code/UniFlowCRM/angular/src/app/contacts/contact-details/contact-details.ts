import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Contacts } from '../../proxy';
import { LocalizationPipe } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import {ContactsourcePipe,ContactstatusPipe} from '../pipes';
@Component({
  standalone: true,
  imports: [
    ContactsourcePipe,
    ContactstatusPipe,
    ReturnBtn,
    LocalizationPipe,
    DatePipe
  ],
  templateUrl: 'contact-details.html'
})
export class ContactDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private contactsService = inject(Contacts.ContactsService);

  id: string = '';

  contact = {} as Contacts.ContactDto;

  constructor() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }

  ngOnInit() {
    this.contactsService.get(this.id).subscribe(c => {
      this.contact = c;
      console.log(c);
    });
  }
}