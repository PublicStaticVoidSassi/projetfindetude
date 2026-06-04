import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit, inject, signal } from '@angular/core';
import { CallsService } from '../proxy/calls/calls.service';
import { Confirmation, ConfirmationService, ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { CallDirection, CallDto } from '../proxy/calls';
import {LocalizationPipe} from '@abp/ng.core';

@Component({
  selector: 'app-calls',
  standalone: true,
  imports: [LocalizationPipe,CommonModule, ThemeSharedModule, NgbDropdownModule],
  providers: [ListService],
  templateUrl: './calls.html',
})
export class CallsComponent implements OnInit {
  private readonly callService = inject(CallsService);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);
  public readonly list = inject(ListService);

  items = {} as PagedResultDto<CallDto>;

  ngOnInit() {
    const streamCreator = (query: PagedAndSortedResultRequestDto) => this.callService.getList(query);

    this.list.hookToQuery(streamCreator).subscribe((response) => {
      this.items = response;
    })
  }

  create() {
    this.router.navigate(['/Calls/form']);
  }

  edit(id: string) {
    this.router.navigate(['/Calls/form', id]);
  }

  openDetails(id: string) {
    this.router.navigate(['/Calls', id]);
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.callService.delete(id).subscribe(() => {
          this.list.get();
          this.toaster.success('::SuccessfullyDeleted');
        });
      }
    });
  }

  protected readonly CallDirection = CallDirection;
}
