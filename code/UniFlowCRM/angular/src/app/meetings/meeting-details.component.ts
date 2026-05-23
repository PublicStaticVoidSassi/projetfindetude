import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MeetingService } from '../proxy/meetings/meeting.service';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule, ConfirmationService, ToasterService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-meeting-details',
  standalone: true,
  imports: [CommonModule, ThemeSharedModule],
  templateUrl: './meeting-details.component.html',
})
export class MeetingDetailsComponent implements OnInit {
  private readonly meetingService = inject(MeetingService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  meeting = signal<any>(null);

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.meetingService.get(id).subscribe((data) => this.meeting.set(data));
    }
  }

  edit() {
    this.router.navigate(['/Meetings/form', this.meeting().id]);
  }

  delete() {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.meetingService.delete(this.meeting().id).subscribe(() => {
          this.toaster.success('::SuccessfullyDeleted');
          this.router.navigate(['/Meetings']);
        });
      }
    });
  }

  goBack() {
    this.router.navigate(['/Meetings']);
  }
}