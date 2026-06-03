import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Accounts } from '../../proxy';
import {LocalizationPipe} from '@abp/ng.core';
import {DatePipe} from '@angular/common';
import {myCurrencyPipe} from '../../shared/currency-pipe';
import {AccountIndustryPipe,AccountTypePipe} from '../pipes';
import {ReturnBtn} from '../../shared/return-btn/return-btn';
import { NoteMiniform } from '../../notes/miniform/note-miniform.component';
import { NoteDto, NotesService } from '../../proxy/notes';
import { NoteMiniUi } from '../../notes/note-mini-ui/note-mini-ui';
//import { AccountsService } from '../../proxy/accounts';
@Component({
  standalone: true,
  imports: [ReturnBtn, LocalizationPipe, DatePipe, myCurrencyPipe, AccountTypePipe, AccountIndustryPipe, NoteMiniform, NoteMiniUi],
  templateUrl: 'account-detail.html'
})
export class AccountDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private accountsService = inject(Accounts.AccountsService);
  notesService = inject(NotesService);
  id: string = '';
  account = {} as Accounts.AccountDto;
  notes : NoteDto[] = [];
  constructor() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }
  ngOnInit() {
      this.accountsService.get(this.id).subscribe(a => {this.account=a;});
      this.notesService.getForAccountByAccountId(this.id).subscribe((e)=>{
        this.notes = e;
      })
  }
}
