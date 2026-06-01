import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CallsService } from '../../proxy/calls/calls.service';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule, ConfirmationService, ToasterService, Confirmation } from '@abp/ng.theme.shared';
import {LocalizationPipe} from '@abp/ng.core';
import { ReturnBtn } from "../../shared/return-btn/return-btn";
@Component({
  selector: 'app-call-details',
  standalone: true,
  imports: [LocalizationPipe, CommonModule, ThemeSharedModule, ReturnBtn, RouterLink],
  templateUrl: './call-details.component.html',
})
export class CallDetailsComponent implements OnInit {
  private readonly callService = inject(CallsService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  call = signal<any>(null);

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.callService.get(id).subscribe((data) => this.call.set(data));
    }
  }

  edit() {
    this.router.navigate(['/Calls/form', this.call().id]);
  }

  delete() {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.callService.delete(this.call().id).subscribe(() => {
          this.toaster.success('::SuccessfullyDeleted');
          this.router.navigate(['/Calls']);
        });
      }
    });
  }

  goBack() {
    this.router.navigate(['/Calls']);
  }
}
