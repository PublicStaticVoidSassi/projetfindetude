import { Component, inject, OnInit } from '@angular/core';
import { ListService, PagedResultDto, PermissionDirective, LocalizationPipe, CoreModule } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService
} from '@abp/ng.theme.shared';
import { myCurrencyPipe } from '../shared/currency-pipe';
import { Router, RouterLink } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

import {
  OpportunityDto,
  OpportunitiesService,
  OpportunityStage,
  OpportunityType,
  SaleStage
} from '../proxy/opportunities';
import { DatePipe, NgClass } from '@angular/common';

import {
  OpportunityStagePipe,
  OpportunityTypePipe,
  SaleStagePipe
} from './pipes';

@Component({
  selector: 'app-opportunities',
  imports: [
    OpportunityStagePipe,
    OpportunityTypePipe,
    SaleStagePipe,
    NgbDropdownModule,
    myCurrencyPipe,
    NgxDatatableModule,
    NgxDatatableListDirective,
    NgxDatatableDefaultDirective,
    LocalizationPipe,
    PermissionDirective,
    DatePipe,
    RouterLink,
    NgClass,
    CoreModule
  ],
  templateUrl: './opportunities.html',
  styleUrl: './opportunities.scss',
  providers: [ListService]
})
export class OpportunitiesComponent implements OnInit {

  // OpportunityStage = OpportunityStage;
  // OpportunityType = OpportunityType;
  // SaleStage = SaleStage;

  private readonly _opportunitiesService = inject(OpportunitiesService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  List = inject(ListService);

  opportunities = {} as PagedResultDto<OpportunityDto>;

  refreshList = () => {
    this.List.get();
  };

  ngOnInit() {
    this.List.hookToQuery(
      (q) => {
        return this._opportunitiesService.getList(q);
      }
    ).subscribe(opportunities => {
      console.log(opportunities);
      this.opportunities = opportunities;
    });
  }

  openDetails(id: string) {
    this.router.navigate(['/Opportunities/' + id]);
  }

  delete(id: string) {
    this.confirm.warn(
      '::Client:Delete:Warning:Text',
      '::Client:Delete:Warning:Title'
    ).subscribe(result => {

      if (result === 'confirm') {

        this._opportunitiesService.delete(id).subscribe(() => {

          this.toaster.success('::Client:Deleted:Success');

          this.refreshList();
        });

      } else {

        this.toaster.show('::Client:Deleted:Canceled');

      }
    });
  }

  edit(id: string) {
    this.router.navigate(['/Opportunities/form/' + id]);
  }

  create() {
    this.router.navigate(['/Opportunities/form/']);
  }

  // search
  searchName: string | null = null;
  loading = false;
  lastQuery : any = {skipCount:0,maxResultCount:10};

  async search(){
    if (this.loading){
      await new Promise(resolve => setTimeout(resolve, 100));
    }
    await new Promise(resolve => setTimeout(resolve, 100));

    this.loading = true;
    console.log(this.lastQuery , this.searchName);
    this._opportunitiesService.getList(
      { ...this.lastQuery , filter: this.searchName } )
      .subscribe(accounts => {this.opportunities=accounts;this.loading = false;});

  }



}
