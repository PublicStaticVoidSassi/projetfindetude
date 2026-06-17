import { Component, inject, OnInit } from '@angular/core';
import { CoreModule, ListService, PagedResultDto, PermissionDirective } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService
} from '@abp/ng.theme.shared';

import { LocalizationPipe } from '@abp/ng.core';
import { Router, RouterLink } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

import { ContactDto, ContactSource, ContactStatus, ContactsService } from '../proxy/contacts';

@Component({
  selector: 'app-contacts',

  imports: [
    NgbDropdownModule,
    NgxDatatableModule,
    NgxDatatableListDirective,
    NgxDatatableDefaultDirective,
    LocalizationPipe,
    // PermissionDirective,
    RouterLink,
    CoreModule
  ],

  templateUrl: './contacts.html',
  styleUrl: './contacts.scss',

  providers: [ListService]
})
export class ContactsComponent implements OnInit {

  private readonly _contactsService = inject(ContactsService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  List = inject(ListService);

  contacts = {} as PagedResultDto<ContactDto>;

  refreshList = () => {
    this.List.get();
  }

  ngOnInit() {
    this.List.hookToQuery(q => {
      return this._contactsService.getList(q);
    }).subscribe(contacts => {
      this.contacts = contacts;
    });
  }

  openDetails(id: string) {
    this.router.navigate(['/Contacts/' + id]);
  }

  delete(id: string) {
    this.confirm.warn(
      "::Client:Delete:Warning:Text",
      "::Client:Delete:Warning:Title"
    ).subscribe(result => {

      if (result == 'confirm') {

        this._contactsService.delete(id).subscribe(() => {
          this.toaster.success("::Client:Deleted:Success");
          this.refreshList();
        });

      } else {
        this.toaster.show("::Client:Deleted:Canceled");
      }

    });
  }

  edit(id: string) {
    this.router.navigate(['/Contacts/form/' + id]);
  }

  create() {
    this.router.navigate(['/Contacts/form/']);
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
    // console.log(this.lastQuery , this.searchName);
    this._contactsService.getList(
      { ...this.lastQuery , filter: this.searchName } )
      .subscribe(accounts => {
        this.contacts=accounts;
        this.loading = false;});

  }



}
