import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { EmailsService } from '../../proxy/emails/emails.service';
import { CommonModule } from '@angular/common';
import {LocalizationPipe} from '@abp/ng.core';
@Component({
  selector: 'app-email-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, LocalizationPipe,ThemeSharedModule],
  templateUrl: './email-form.component.html',
})
export class EmailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly emailService = inject(EmailsService);
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
      this.emailService.get(this.id).subscribe((email) => {
        this.form.patchValue(email);
        this.loading.set(false);
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      toAddress: ['', [Validators.required, Validators.email]],
      subject: ['', [Validators.required, Validators.maxLength(256)]],
      body: ['', [Validators.required]],
    });
  }

  save() {
    if (this.form.invalid) return;

    this.loading.set(true);
    const request = this.id
      ? this.emailService.update(this.id, this.form.value)
      : this.emailService.create(this.form.value);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Emails']);
      },
      error: () => this.loading.set(false),
    });
  }

  cancel() {
    this.router.navigate(['/Emails']);
  }
}