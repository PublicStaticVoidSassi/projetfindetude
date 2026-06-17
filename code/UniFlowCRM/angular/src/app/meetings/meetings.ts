import { CoreModule, ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { MeetingsService } from '../proxy/meetings/meetings.service';
import { MeetingDto } from '../proxy/meetings/models';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { RouterLink,Router } from '@angular/router';
import { LocalizationPipe } from '@abp/ng.core';
import {
  NgbDropdown,
  NgbDropdownButtonItem,
  NgbDropdownItem,
  NgbDropdownMenu,
  NgbDropdownToggle
} from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-meetings',
  standalone: true,
  imports: [LocalizationPipe, CommonModule, ThemeSharedModule, RouterLink, NgbDropdown, NgbDropdownButtonItem, NgbDropdownItem, NgbDropdownMenu, NgbDropdownToggle, CoreModule],
  templateUrl: './meetings.html',
  styleUrl: './meetings.scss',
  providers: [ListService],
})
export class Meetings implements OnInit {
  private readonly router = inject(Router);
  private readonly meetingService = inject(MeetingsService);
  public readonly list = inject(ListService);

  items = {} as PagedResultDto<MeetingDto>;

  ngOnInit() {
    const meetingStreamCreator = (query: PagedAndSortedResultRequestDto) => this.meetingService.getList(query);

    this.list.hookToQuery(meetingStreamCreator).subscribe((response) => {
      this.items = response;
    });
  }
  create(){
    this.router.navigate(['/Meetings/form']);
  }
  openDetails(id: number) {
    this.router.navigate(['/Meetings/', id]);
  }
  edit(id: string) {
    this.router.navigate(['/Meetings/form', id]);
  }
  delete(id: string) {
    if (confirm('Are you sure?')) {
      this.meetingService.delete(id).subscribe(() => {
        this.list.get();
      });
    }
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
    this.meetingService.getList(
      { ...this.lastQuery , filter: this.searchName } )
      .subscribe(accounts => {this.items=accounts;this.loading = false;});

  }



}
