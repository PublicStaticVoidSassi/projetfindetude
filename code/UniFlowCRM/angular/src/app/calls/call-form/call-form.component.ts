import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { CallsService ,callStatusOptions,callDirectionOptions} from '../../proxy/calls';
import { CommonModule } from '@angular/common';
import { LocalizationPipe } from '@abp/ng.core';
import { AccountsLookup,ContactsLookup,LeadsLookup,OpportunitiesLookup,UsersLookup } from '../../shared/lookup-components';
@Component({
  selector: 'app-call-form',
  standalone: true,
  imports: [AccountsLookup,ContactsLookup,LeadsLookup,OpportunitiesLookup,UsersLookup,LocalizationPipe,CommonModule, ReactiveFormsModule, ThemeSharedModule],
  templateUrl: './call-form.component.html',
})
export class CallFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly callService = inject(CallsService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);

  calldirections = callDirectionOptions;
  callstatuses = callStatusOptions;

  form: FormGroup = this.fb.group({});
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();

    if (this.id) {
      this.loading.set(true);
      this.callService.get(this.id).subscribe((call) => {
        this.form.patchValue(call);
        this.loading.set(false);
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      status: [null,Validators.required],
      direction: [null,Validators.required],
      startTime: [null,Validators.required],
      endTime: [null],
      duration: [null, [Validators.required,Validators.min(0)]],
      phoneNumber: ['', [Validators.required,Validators.maxLength(32)]],
      accountId: [null],
      contactId: [null],
      opportunityId: [null],
      leadId: [null],
      owner: [null],
    });
  }

  save() {
    if (this.form.invalid) return;

    this.loading.set(true);
    const request = this.id
      ? this.callService.update(this.id, this.form.value)
      : this.callService.create(this.form.value);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Calls']);
      },
      error: () => this.loading.set(false),
    });
  }

  cancel() {
    this.router.navigate(['/Calls']);
  }
}