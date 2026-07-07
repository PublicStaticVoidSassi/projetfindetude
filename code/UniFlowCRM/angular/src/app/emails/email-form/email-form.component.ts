import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { EmailsService } from '../../proxy/emails/emails.service';
import { EmailStatus, emailStatusOptions } from '../../proxy/emails';
import { CommonModule } from '@angular/common';
import { AccountsLookup, ContactsLookup, LeadsLookup, OpportunitiesLookup, UsersLookup } from "../../shared/lookup-components";
import { LocalizationPipe } from '@abp/ng.core';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import { RequiredTag } from '../../shared/required-tag/required-tag';
@Component({
  selector: 'app-email-form',
  standalone: true,
  imports: [AccountsLookup, ContactsLookup, LeadsLookup, OpportunitiesLookup, UsersLookup, CommonModule, ReactiveFormsModule, LocalizationPipe, ThemeSharedModule, ReturnBtn, RequiredTag],
  templateUrl: './email-form.component.html',
})
export class EmailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly emailService = inject(EmailsService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);
  emailStatuses = emailStatusOptions;
  form: FormGroup = this.fb.group({});
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();
    setTimeout((() => {
      this.load();
    }), 2500)
  }
  load() {
    if (this.id) {
      this.loading.set(true);
      this.emailService.get(this.id).subscribe((email) => {
        this.form.patchValue({
          ...email,
          accountID: email.account?.id,
          contactID: email.contact?.id,
          opportunityID: email.opportunity?.id,
          leadID: email.lead?.id,
          ownerID: email.owner?.id
        });
        this.loading.set(false);
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      subject: ['', [Validators.required]],
      body: ['', [Validators.required]],
      status: [EmailStatus.Draft, Validators.required],

      from: ['uniflowcrm67@gmail.com', Validators.email],
      to: ['', [Validators.required, Validators.email]],
      cc: ['', Validators.email],
      bcc: ['', Validators.email],

      sentAt: [null],
      isHtml: [true],

      accountID: [null],
      contactID: [null],
      opportunityID: [null],
      leadID: [null],
      ownerID: [null],
    });
  }

  save() {
    if (this.form.invalid) return;

    this.loading.set(true);
    const request = this.id
      ? this.emailService.update(this.id, this.form.value)
      : this.emailService.create(this.form.value);

    request.subscribe((res) => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Emails',res.id]);
      });
  }

  cancel() {
    this.router.navigate(['/Emails']);
  }
}
