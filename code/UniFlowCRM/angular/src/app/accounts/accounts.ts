import { Component, inject, OnInit } from '@angular/core';
import {Accounts as AccountsModule} from '../proxy/index';
import { BaseCoreModule, ListService, PagedResultDto, PermissionDirective } from '@abp/ng.core';
import {NgxDatatableModule} from '@swimlane/ngx-datatable';
import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService
} from '@abp/ng.theme.shared';
import {LocalizationPipe} from '@abp/ng.core';
import {myCurrencyPipe} from '../shared/currency-pipe';
import {AccountTypePipe,AccountIndustryPipe} from './pipes';
import { Router } from '@angular/router';
import {NgbDropdownModule} from '@ng-bootstrap/ng-bootstrap'
import { AccountIndustry, AccountRequestDto, AccountType ,accountTypeOptions, accountIndustryOptions} from '../proxy/accounts';
type AccountDto = AccountsModule.AccountDto;
@Component({
  selector: 'app-accounts',
  imports: [NgbDropdownModule, AccountIndustryPipe, AccountTypePipe, myCurrencyPipe, NgxDatatableModule, NgxDatatableListDirective, NgxDatatableDefaultDirective, LocalizationPipe, PermissionDirective, BaseCoreModule],
  templateUrl: './accounts.html',
  styleUrl: './accounts.scss',
  providers: [ListService]
})
export class AccountsComponent implements OnInit{
  private readonly AccountsService = inject(AccountsModule.AccountsService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);
  List = inject(ListService);
  Accounts = {} as PagedResultDto<AccountDto>;
  accountTypeOptions = accountTypeOptions;
  accountIndustryOptions = accountIndustryOptions;
  refreshList = () =>{
    this.List.get();
  }
    searchIndustry: AccountIndustry | null = null;
    searchType: AccountType | null = null;
    searchName: string | null = null;
    lastQuery : any = {skipCount:0,maxResultCount:10};
  async search(){
    if (this.loading){
      return
    }
    await new Promise(resolve => setTimeout(resolve, 100));

    this.loading = true;
    console.log({
      ...this.lastQuery,
      name: this.searchName,
      type: this.searchType,
      industry: this.searchIndustry
    });
    this.AccountsService.getList(
      { ...this.lastQuery , name: this.searchName,type: this.searchType,industry: this.searchIndustry })
      .subscribe(accounts => {this.Accounts=accounts;this.loading = false;});

  }
  loading = false;
  ngOnInit() {
  this.List.hookToQuery(
      (q)=>{
        console.log(q);
        this.lastQuery = q;
        return this.AccountsService.getList({ ...q , name: this.searchName,type: this.searchType,industry: this.searchIndustry });
      }
      ).subscribe(
        accounts => {
          this.Accounts=accounts
        }

      )
  }
  openDetails(id: string){
    this.router.navigate(['/Accounts/'+id]);
  }
  delete(id: string){
    this.confirm.warn("::Client:Delete:Warning:Text","::Client:Delete:Warning:Title").subscribe(
      result => {
        if (result == 'confirm'){
          this.AccountsService.delete(id).subscribe(account => {
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

    this.router.navigate(['/Accounts/form/'+id]);
  }
  create(){
    // this.toaster.error("not implemented yet");
    this.router.navigate(['/Accounts/form/']);
  }

  protected readonly AccountType = AccountType;
}
