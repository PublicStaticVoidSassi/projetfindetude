import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';

import {
  MeetingsService,
  MeetingStatus,
  meetingStatusOptions
} from '../proxy/meetings';

import { CommonModule } from '@angular/common';
import { LocalizationPipe } from '@abp/ng.core';

import {
  AccountsLookup,
  ContactsLookup,
  LeadsLookup,
  OpportunitiesLookup,
  UsersLookup
} from '../shared/lookup-components';
import { ReturnBtn } from '../shared/return-btn/return-btn';

@Component({
  selector: 'app-meeting-form',
  standalone: true,
  imports: [
    AccountsLookup,
    ContactsLookup,
    LeadsLookup,
    OpportunitiesLookup,
    UsersLookup,
    LocalizationPipe,
    CommonModule,
    ReactiveFormsModule,
    ThemeSharedModule,
    ReturnBtn
  ],
  templateUrl: './meeting-form.component.html',
})
export class MeetingFormComponent implements OnInit {

  private readonly fb = inject(FormBuilder);
  private readonly meetingService = inject(MeetingsService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);

  meetingStatuses = meetingStatusOptions;

  form: FormGroup = this.fb.group({});
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();

    if (this.id) {
      this.loading.set(true);

      this.meetingService.get(this.id).subscribe((meeting) => {
        setTimeout(() => {
          this.form.patchValue({
            ...meeting,
            accountID: meeting.account?.id,
            contactID: meeting.contact?.id,
            opportunityID: meeting.opportunity?.id,
            leadID: meeting.lead?.id,
            ownerID: meeting.owner?.id,
          });
          this.loading.set(false);
        }, 1000)
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      status: [MeetingStatus.Planned],
      startTime: [null, [Validators.required]],
      endTime: [null],
      location: [''],

      accountID: [null],
      contactID: [null],
      opportunityID: [null],
      leadID: [null],
      ownerID: [null],
    });
  }

  save() {
    if (this.form.invalid) {
      console.log(this.form.errors);
      return;
    }

    this.loading.set(true);

    const request = this.id
      ? this.meetingService.update(this.id, this.form.value)
      : this.meetingService.create(this.form.value);

    request.subscribe((res) => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Meetings',res.id]);
      });
  }

  cancel() {
    this.router.navigate(['/Meetings']);
  }
}
