import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Opportunities } from '../../proxy';
import { LocalizationPipe } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import {myCurrencyPipe} from '../../shared/currency-pipe';
@Component({
  standalone: true,
  imports: [
    myCurrencyPipe,
    ReturnBtn,
    LocalizationPipe,
    DatePipe,
    RouterLink
  ],
  templateUrl: 'opportunity-details.html'
})
export class OpportunityDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private opportunitiesService = inject(Opportunities.OpportunitiesService);

  id: string = '';

  opportunity = {} as Opportunities.OpportunityDto;

  constructor() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
  }

  ngOnInit() {
    this.opportunitiesService.get(this.id).subscribe(o => {
      this.opportunity = o;
      console.log(o);
    });
  }
}
