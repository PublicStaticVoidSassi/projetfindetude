import { Component, inject, OnInit } from '@angular/core';
import { ListService, PagedResultDto, PermissionDirective } from '@abp/ng.core';
import {NgxDatatableModule} from '@swimlane/ngx-datatable';
import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService
} from '@abp/ng.theme.shared';
import {LocalizationPipe} from '@abp/ng.core';
import {myCurrencyPipe} from '../shared/currency-pipe';
import { Router, RouterLink } from '@angular/router';
import {NgbDropdownModule} from '@ng-bootstrap/ng-bootstrap'
import { LeadDto,LeadSource,LeadStatus,LeadsService } from '../proxy/leads';
import { LeadsourcePipe,LeadstatusPipe } from './pipes';
@Component({
  selector: 'app-leads',
  imports: [LeadsourcePipe, LeadstatusPipe, NgbDropdownModule, myCurrencyPipe, NgxDatatableModule, NgxDatatableListDirective, NgxDatatableDefaultDirective, LocalizationPipe, PermissionDirective, RouterLink],
  templateUrl: './leads.html',
  styleUrl: './leads.scss',
  providers: [ListService]
})
export class LeadsComponent implements OnInit{
  // LeadStatus = LeadStatus;
  // LeadSource = LeadSource;
  private readonly _leadsService = inject(LeadsService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);
  List = inject(ListService);
  leads = {} as PagedResultDto<LeadDto>;
  refreshList = () =>{
    this.List.get();
  }
  ngOnInit() {
  this.List.hookToQuery(
      (q)=>{
        return this._leadsService.getList(q)
      }
      ).subscribe(leads => {this.leads=leads})
  }
  openDetails(id: string){
    this.router.navigate(['/Leads/'+id]);
  }
  delete(id: string){
    this.confirm.warn("::Client:Delete:Warning:Text","::Client:Delete:Warning:Title").subscribe(
      result => {
        if (result == 'confirm'){
          this._leadsService.delete(id).subscribe(account => {
            this.toaster.success("::Client:Deleted:Success");
            this.refreshList();
          });
        }else{
          this.toaster.show("::Client:Deleted:Canceled");
        }
      }
    )
  }
  edit(id: string){
    // this.toaster.error("not implemented yet");

    this.router.navigate(['/Leads/form/'+id]);
  }
  create(){
    // this.toaster.error("not implemented yet");
    this.router.navigate(['/Leads/form/']);
  }
}

// @Component({
//   selector: 'app-lead',
//   imports: [],
//   templateUrl: './lead.html',
//   styleUrl: './lead.scss',
// })
// export class Lead {

// }
