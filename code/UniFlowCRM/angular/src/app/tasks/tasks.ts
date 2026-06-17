import { CoreModule, ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { TasksService } from '../proxy/tasks/tasks.service';
import { TaskDto } from '../proxy/tasks/models';
import { CommonModule } from '@angular/common';
import { Confirmation, ConfirmationService, ThemeSharedModule, ToasterService } from '@abp/ng.theme.shared';
import { RouterLink, Router } from '@angular/router';
import { LocalizationPipe } from '@abp/ng.core';
import {
  NgbDropdown,
  NgbDropdownButtonItem,
  NgbDropdownItem,
  NgbDropdownMenu,
  NgbDropdownToggle
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [LocalizationPipe, CommonModule, ThemeSharedModule, RouterLink, NgbDropdown, NgbDropdownButtonItem, NgbDropdownItem, NgbDropdownMenu, NgbDropdownToggle, CoreModule],
  templateUrl: './tasks.html',
  styleUrl: './tasks.scss',
  providers: [ListService],
})
export class Tasks implements OnInit {
  private readonly router = inject(Router);
  private readonly taskService = inject(TasksService);
  private readonly confirmation = inject(ConfirmationService);
  public readonly list = inject(ListService);
  private readonly toaster = inject(ToasterService);

  items = {} as PagedResultDto<TaskDto>;

  ngOnInit() {
    const taskStreamCreator = (query: PagedAndSortedResultRequestDto) => this.taskService.getList(query);

    this.list.hookToQuery(taskStreamCreator).subscribe((response) => {
      this.items = response;
    });
  }

  create() {
    this.router.navigate(['/Tasks/form']);
  }
  edit(id: string) {
    this.router.navigate(['/Tasks/form', id]);
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.taskService.delete(id).subscribe(() => {
          this.list.get();
          this.toaster.success('::SuccessfullyDeleted');
        });
      }
    });
  }

  openDetails(id) {
  this.router.navigate(['/Tasks/', id]);
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
    this.taskService.getList(
      { ...this.lastQuery , filter: this.searchName } )
      .subscribe(accounts => {this.items=accounts;this.loading = false;});

  }




}
