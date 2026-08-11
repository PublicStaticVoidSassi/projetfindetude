import { Component, inject, OnInit } from '@angular/core';
import { CoreModule, ListService, PagedResultDto } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService
} from '@abp/ng.theme.shared';
import { LocalizationPipe } from '@abp/ng.core';
import { Router, RouterLink } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap'
import { LeadDto, LeadsService, LeadStatus } from '../proxy/leads';
import { LeadsourcePipe, LeadstatusPipe } from './pipes';
import { accountIndustryOptions, accountTypeOptions } from '../proxy/accounts';
@Component({
  selector: 'app-leads',
  imports: [LeadsourcePipe, LeadstatusPipe, NgbDropdownModule, NgxDatatableModule, NgxDatatableListDirective, NgxDatatableDefaultDirective, LocalizationPipe, RouterLink, CoreModule],
  templateUrl: './leads.html',
  styleUrl: './leads.scss',
  providers: [ListService]
})
export class LeadsComponent implements OnInit {
  // workaround($e: any) {
  //     throw new Error('Method not implemented.');
  // }
  LeadStatus = LeadStatus;
  // LeadSource = LeadSource;
  private readonly _leadsService = inject(LeadsService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);
  List = inject(ListService);
  leads = {} as PagedResultDto<LeadDto>;
  refreshList = () => {
    this.List.get();
  }
  ngOnInit() {
    this.List.hookToQuery(
      (q) => {
        return this._leadsService.getList(q)
      }
    ).subscribe(leads => { this.leads = leads })
  }
  openDetails(id: string) {
    this.router.navigate(['/Leads/' + id]);
  }
  delete(id: string) {
    this.confirm.warn("::Client:Delete:Warning:Text", "::Client:Delete:Warning:Title").subscribe(
      result => {
        if (result == 'confirm') {
          this._leadsService.delete(id).subscribe(() => {
            this.toaster.success("::Client:Deleted:Success");
            this.refreshList();
          });
        } else {
          this.toaster.show("::Client:Deleted:Canceled");
        }
      }
    )
  }
  edit(id: string) {
    // this.toaster.error("not implemented yet");

    this.router.navigate(['/Leads/form/' + id]);
  }
  create() {
    // this.toaster.error("not implemented yet");
    this.router.navigate(['/Leads/form/']);
  }

  // search
  searchName: string | null = null;
  loading = false;
  lastQuery: any = { skipCount: 0, maxResultCount: 10 };

  async search() {
    if (this.loading) {
      await new Promise(resolve => setTimeout(resolve, 100));
    }
    await new Promise(resolve => setTimeout(resolve, 100));
    this.loading = true;
    console.log(this.lastQuery, this.searchName);
    this._leadsService.getList(
      { ...this.lastQuery, filter: this.searchName })
      .subscribe(accounts => { this.leads = accounts; this.loading = false; });

  }

  // protected readonly accountIndustryOptions = accountIndustryOptions;
  // protected readonly accountTypeOptions = accountTypeOptions;
}
