import { CoreModule, ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit, inject, signal } from '@angular/core';
import { EmailsService } from '../proxy/emails/emails.service';
import { Confirmation, ConfirmationService, ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import {LocalizationPipe} from '@abp/ng.core';
import { EmailDto } from '../proxy/emails';
import { ReturnBtn } from '../shared/return-btn/return-btn';

@Component({
  selector: 'app-emails',
  standalone: true,
  imports: [CommonModule, LocalizationPipe, ThemeSharedModule, NgbDropdownModule, ReturnBtn, CoreModule],
  providers: [ListService],
  templateUrl: './emails.component.html',
})
export class EmailsComponent implements OnInit {
  private readonly emailService = inject(EmailsService);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);
  public readonly list = inject(ListService);

  items = {} as PagedResultDto<EmailDto>;
  ngOnInit() {
    const streamCreator = (query: PagedAndSortedResultRequestDto) => this.emailService.getList(query);

    this.list.hookToQuery(streamCreator).subscribe((response) => {
      this.items = response;
    });
  }

  create() {
    this.router.navigate(['/Emails/form']);
  }

  edit(id: string) {
    this.router.navigate(['/Emails/form', id]);
  }

  openDetails(id: string) {
    this.router.navigate(['/Emails', id]);
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.emailService.delete(id).subscribe(() => {
          this.list.get();
          this.toaster.success('::SuccessfullyDeleted');
        });
      }
    });
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
    this.emailService.getList(
      { ...this.lastQuery , filter: this.searchName } )
      .subscribe(accounts => {this.items=accounts;this.loading = false;});

  }



}
