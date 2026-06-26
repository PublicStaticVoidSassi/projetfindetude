import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { EmailsService } from '../../proxy/emails/emails.service';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule, ConfirmationService, ToasterService, Confirmation } from '@abp/ng.theme.shared';
import { LocalizationPipe } from '@abp/ng.core';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import { EmailStatus, emailStatusOptions } from '../../proxy/emails';

@Component({
  selector: 'app-email-details',
  standalone: true,
  imports: [CommonModule, ThemeSharedModule, LocalizationPipe, ReturnBtn, RouterLink],
  templateUrl: './email-details.component.html',
})
export class EmailDetailsComponent implements OnInit {
  private readonly emailService = inject(EmailsService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  email = signal<any>(null);
  reload() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.emailService.get(id).subscribe((data) => this.email.set(data));
    }
  }
  ngOnInit() {
    this.reload();
  }

  edit() {
    this.router.navigate(['/Emails/form', this.email().id]);
  }

  delete() {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.emailService.delete(this.email().id).subscribe(() => {
          this.toaster.success('::SuccessfullyDeleted');
          this.router.navigate(['/Emails']);
        });
      }
    });
  }

  goBack() {
    this.router.navigate(['/Emails']);
  }

  protected readonly emailStatusOptions = emailStatusOptions;
  protected readonly EmailStatus = EmailStatus;

  protected send() {
    this.confirmation.info("::Email:Send:Text", "::Email:Send:Confirmation").subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.emailService.sendEmail(this.email().id).subscribe(() => {
          this.toaster.success(this.email().id, "::Email:Sent:Successfully");
          this.reload();
        });
      }
    })
  }
}
