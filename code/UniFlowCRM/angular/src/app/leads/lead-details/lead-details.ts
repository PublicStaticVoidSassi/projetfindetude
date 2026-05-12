import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Leads } from '../../proxy';
import { LocalizationPipe } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';

@Component({
  standalone: true,
  imports: [
    ReturnBtn,
    LocalizationPipe,
    DatePipe
  ],
  templateUrl: 'lead-details.html'
})
export class LeadDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private leadsService = inject(Leads.LeadsService);

  id: string = '';

  lead = {} as Leads.LeadDto;

  constructor() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }

  ngOnInit() {
    this.leadsService.get(this.id).subscribe(l => {
      this.lead = l;
      console.log(l);
    });
  }
}