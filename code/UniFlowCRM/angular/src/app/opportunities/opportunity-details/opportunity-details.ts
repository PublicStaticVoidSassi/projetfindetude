import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Opportunities } from '../../proxy';
import { AuthService, LocalizationPipe, ConfigStateService, PermissionDirective } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import {myCurrencyPipe} from '../../shared/currency-pipe';
import { NoteMiniform } from '../../notes/miniform/note-miniform.component';
import { NoteMiniUi } from '../../notes/note-mini-ui/note-mini-ui';
import { NoteDto, NotesService } from '../../proxy/notes';
import { ToasterService } from '@abp/ng.theme.shared';
import { SaleStage,OpportunityStage } from '../../proxy/opportunities';
import { IdentityRoleService } from '@abp/ng.identity/proxy';
@Component({
  standalone: true,
  imports: [
    myCurrencyPipe,
    ReturnBtn,
    LocalizationPipe,
    DatePipe,
    RouterLink,
    NoteMiniform,
    NoteMiniUi,
    PermissionDirective
  ],
  templateUrl: 'opportunity-details.html'
})
export class OpportunityDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private role = inject(ConfigStateService);
  private opportunitiesService = inject(Opportunities.OpportunitiesService);
  toaster = inject(ToasterService);
  notesservice = inject(NotesService);
  id: string = '';
  notes :  NoteDto[]= []
  opportunity = {} as Opportunities.OpportunityDto;

  canClose(): boolean {
    return this.role.getAll().currentUser.roles.includes("admin") || this.role.getAll().currentUser.roles.includes("Directeur")
  }

  close(state: 'won'|'lost'){
      this.opportunitiesService.close(this.opportunity.id!,state === 'won').subscribe(e=>{
        this.toaster.success((state==='won')?'::Opportunity:Celebrate':'::Opportunity:Mourn',"::Opportunity:Closed");
        this.opportunity = e;
      })
  }

  load() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.opportunitiesService.get(this.id).subscribe(o => {
      this.opportunity = o;
    });
    this.notesservice.getForOpportunityByOpportunityId(this.id).subscribe(e=>{
      this.notes = e;
    })
  }
  ngOnInit() {
    this.load();
  }

  protected readonly SaleStage = SaleStage;
  OpportunityStage = OpportunityStage;
}
