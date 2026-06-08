import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { CallsService ,callStatusOptions,callDirectionOptions} from '../../proxy/calls';
import { CommonModule } from '@angular/common';
import { LocalizationPipe } from '@abp/ng.core';
import { AccountsLookup,ContactsLookup,LeadsLookup,OpportunitiesLookup,UsersLookup } from '../../shared/lookup-components';
import { ReturnBtn } from '../../shared/return-btn/return-btn';
import { RequiredTag } from '../../shared/required-tag/required-tag';
@Component({
  selector: 'app-call-form',
  standalone: true,
  imports: [AccountsLookup, ContactsLookup, LeadsLookup, OpportunitiesLookup, UsersLookup, LocalizationPipe, CommonModule, ReactiveFormsModule, ThemeSharedModule, ReturnBtn, RequiredTag],
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

  form: FormGroup ;
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();

    if (this.id) {
      this.loading.set(true);
      this.callService.get(this.id).subscribe((call) => {
        // this.form.patchValue(call);
        setTimeout(()=>{
          this.form.patchValue({
            ...call,
            phoneNumber: call.phoneNumber?.split(' ')[1],
            phoneCode:call.phoneNumber?.split(' ')[0],
            accountID:call.account?.id,
            leadID:call.lead?.id,
            contactID:call.contact?.id,
            opportunityID:call.opportunity?.id,
            ownerID:call.owner?.id,
          })
          this.loading.set(false);

        },500);

      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      status: [null],
      direction: [null],
      startTime: [new Date().toLocalISOString(),Validators.required],
      endTime: [new Date()],
      duration: [null, [Validators.required,Validators.min(0)]],
      phoneCode: ['', [Validators.required,Validators.maxLength(32)]],
      phoneNumber: ['', [Validators.required,Validators.maxLength(32)]],
      accountID: [null],
      contactID: [null],
      opportunityID: [null],
      leadID: [null],
      ownerID: [null],
    });
  }

  save() {
    // console.log(this.form.value);
    if (this.form.invalid)
      // console.log(this.form.errors);
      return;

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
