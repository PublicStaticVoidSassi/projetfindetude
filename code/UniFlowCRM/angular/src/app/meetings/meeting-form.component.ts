import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { MeetingService } from '../proxy/meetings/meeting.service';
import { CommonModule } from '@angular/common';
import {LocalizationPipe} from '@abp/ng.core';
@Component({
  selector: 'app-meeting-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ThemeSharedModule, LocalizationPipe],
  templateUrl: './meeting-form.component.html',
})
export class MeetingFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly meetingService = inject(MeetingService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);

  form: FormGroup = this.fb.group({});
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();

    if (this.id) {
      this.loading.set(true);
      this.meetingService.get(this.id).subscribe((meeting) => {
        this.form.patchValue(meeting);
        this.loading.set(false);
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(128)]],
      description: ['', [Validators.maxLength(500)]],
      location: ['', [Validators.maxLength(256)]],
    });
  }

  save() {
    if (this.form.invalid) return;

    this.loading.set(true);
    const request = this.id
      ? this.meetingService.update(this.id, this.form.value)
      : this.meetingService.create(this.form.value);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Meetings']);
      },
      error: () => this.loading.set(false),
    });
  }

  cancel() {
    this.router.navigate(['/Meetings']);
  }
}