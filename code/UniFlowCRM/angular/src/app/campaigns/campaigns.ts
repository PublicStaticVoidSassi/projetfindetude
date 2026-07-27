import { Component, inject, OnInit } from '@angular/core';
import { BaseCoreModule, ListService, LocalizationPipe, PermissionDirective } from '@abp/ng.core';
import { DataTableColumnCellDirective, DataTableColumnDirective, DatatableComponent } from '@swimlane/ngx-datatable';
import {
  NgbDropdown,
  NgbDropdownButtonItem,
  NgbDropdownItem,
  NgbDropdownMenu,
  NgbDropdownToggle
} from '@ng-bootstrap/ng-bootstrap';
import {
  ConfirmationService,
  NgxDatatableDefaultDirective,
  NgxDatatableListDirective,
  ToasterService
} from '@abp/ng.theme.shared';
import { CampaignService } from '../proxy/campaigns';
import { Router } from '@angular/router';

@Component({
  selector: 'app-campaigns',
  imports: [
    BaseCoreModule,
    DataTableColumnCellDirective,
    DataTableColumnDirective,
    DatatableComponent,
    LocalizationPipe,
    NgbDropdown,
    NgbDropdownButtonItem,
    NgbDropdownItem,
    NgbDropdownMenu,
    NgbDropdownToggle,
    NgxDatatableDefaultDirective,
    NgxDatatableListDirective,
    PermissionDirective
  ],
  templateUrl: './campaigns.html',
  styleUrl: './campaigns.scss',
  providers: [ListService]
})
export class Campaigns implements OnInit{
  private readonly campaignsService = inject(CampaignService);
  list = inject(ListService);
  campaigns = {} as any;
  searchName: string;
  loading: boolean;
  router = inject(Router);
  confirm= inject(ConfirmationService);
  toaster= inject(ToasterService);
  loadCampaigns(): void {
    this.list.hookToQuery((q)=>{
      this.lastQuery = q;
      return this.campaignsService.getList(q);
    }).subscribe(r=>this.campaigns = r);
  }

ngOnInit() {
  this.loadCampaigns()
}

  openDetails(id: string) {
    // console.log(id);
    this.router.navigate(['/Campaigns/' + id]);
  }

  delete(id: string) {
    this.confirm.warn(
      "Cette action est irréversible.", // "::Client:Delete:Warning:Text",
      "Êtes-vous sûr de vouloir supprimer cette campagne ?", // "::Client:Delete:Warning:Title"
    ).subscribe(result => {

      if (result == 'confirm') {

        this.campaignsService.delete(id).subscribe(() => {
          this.toaster.success(
            "La campagne a été supprimée avec succès."
            // "::Client:Deleted:Success"
          );
          this.refreshList();
        });

      } else {
        this.toaster.show(
          "La suppression a été annulée."
          // "::Client:Deleted:Canceled"
        );
      }

    });
  }

  refreshList() {
        this.campaignsService.getList(this.lastQuery).subscribe(r=>this.campaigns = r);
    }

  edit(id: string) {
    this.router.navigate(['/Campaigns/form/' + id]);
  }

  create() {
    this.router.navigate(['/Campaigns/form/']);
  }

  lastQuery : any = {skipCount:0,maxResultCount:10};
  async search(){
    if (this.loading){
      await new Promise(resolve => setTimeout(resolve, 100));
    }
    await new Promise(resolve => setTimeout(resolve, 100));

    this.loading = true;
    // console.log(this.lastQuery , this.searchName);
    this.campaignsService.getList(
      { ...this.lastQuery , name: this.searchName } )
      .subscribe(accounts => {this.campaigns =accounts;this.loading = false;});

  }
}
