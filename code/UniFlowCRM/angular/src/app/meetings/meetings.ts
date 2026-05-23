import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { MeetingService } from '../proxy/meetings/meeting.service';
import { MeetingDto } from '../proxy/meetings/models';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { RouterLink,Router } from '@angular/router';
import { LocalizationPipe } from '@abp/ng.core';
@Component({
  selector: 'app-meetings',
  standalone: true,
  imports: [LocalizationPipe,CommonModule, ThemeSharedModule, RouterLink],
  templateUrl: './meetings.html',
  styleUrl: './meetings.scss',
  providers: [ListService],
})
export class Meetings implements OnInit {
  private readonly router = inject(Router);
  private readonly meetingService = inject(MeetingService);
  public readonly list = inject(ListService);

  meetings = {} as PagedResultDto<MeetingDto>;

  ngOnInit() {
    const meetingStreamCreator = (query: PagedAndSortedResultRequestDto) => this.meetingService.getList(query);

    this.list.hookToQuery(meetingStreamCreator).subscribe((response) => {
      this.meetings = response;
    });
  }
  create(){
    this.router.navigate(['/Meetings/form']);
  }
  delete(id: string) {
    if (confirm('Are you sure?')) {
      this.meetingService.delete(id).subscribe(() => {
        this.list.get();
      });
    }
  }
}
