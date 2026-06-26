import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Leads } from '../../proxy';
import { LocalizationPipe } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import { NoteMiniUi } from '../../notes/note-mini-ui/note-mini-ui';
import { NoteDto, NotesService } from '../../proxy/notes';
import { NoteMiniform } from '../../notes/miniform/note-miniform.component';
import { LeadStatus } from '../../proxy/leads';
import { Toaster, ToasterService } from '@abp/ng.theme.shared';
import { MiniOpportunity } from "src/app/shared/mini-opportunity/mini-opportunity";

@Component({
  standalone: true,
  imports: [
    ReturnBtn,
    LocalizationPipe,
    DatePipe,
    RouterLink,
    NoteMiniUi,
    NoteMiniform,
    MiniOpportunity
  ],
  templateUrl: 'lead-details.html'
})
export class LeadDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private leadsService = inject(Leads.LeadsService);
  private toaster = inject(ToasterService);

  notesService = inject(NotesService);
  notes: NoteDto[] = []

  id: string = '';

  lead = {} as Leads.LeadDto;

  constructor() {

  }
  ngOnInit() {
    this.load();
  }
  load() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.leadsService.get(this.id).subscribe(l => {
      this.lead = l;
    });
    this.notesService.getForLeadByLeadId(this.id).subscribe(notes => {
      this.notes = notes;
    })
  }
  convert() {
    console.log("entered");
    this.leadsService.convert(this.id).subscribe(contact => {
      this.toaster.success("::Lead:Converted", contact.id);
      this.load();
    })
  }
  protected readonly LeadStatus = LeadStatus;
}
