// lead-form.component.ts

import { enumToDropdown } from '../../shared/enum-to-dropdown';
import { ReturnBtn } from '../../shared/return-btn/return-btn';

import {
  IdentityUserDto,
  IdentityUserService
} from '@abp/ng.identity/proxy';

import {
  Component,
  inject,
  OnInit
} from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule
} from '@angular/forms';

import {
  LeadStatus,
  LeadSource,
  CreateUpdateLeadDto
} from '../../proxy/leads';

import { LocalizationPipe } from '@abp/ng.core';

import { LeadsService } from '../../proxy/leads/leads.service';

import { ToasterService } from '@abp/ng.theme.shared';

import { ActivatedRoute } from '@angular/router';
import { AccountDto, AccountsService } from 'src/app/proxy/accounts';

@Component({
  selector: 'app-lead-form',
  imports: [
    ReturnBtn,
    ReactiveFormsModule,
    LocalizationPipe
  ],
  templateUrl: './lead-form.html',
  styleUrl: './lead-form.scss',
})
export class LeadFormComponent implements OnInit {

  private fb = inject(FormBuilder);

  private userService = inject(IdentityUserService);

  private leadsService = inject(LeadsService);
  private accountService = inject(AccountsService);
  private toaster = inject(ToasterService);

  private route = inject(ActivatedRoute);

  leadStatuses = enumToDropdown(LeadStatus);

  leadSources = enumToDropdown(LeadSource);

  users: IdentityUserDto[] = [];
  accounts: AccountDto[] = [];
  id: string | null = null;

  form: FormGroup = this.fb.group({

    firstName: ['', Validators.required],

    lastName: [null],

    description: [null],

    status: [LeadStatus[this.leadStatuses[0] as keyof typeof LeadStatus]],

    source: [LeadSource[this.leadSources[0] as keyof typeof LeadSource]],

    phoneCode: [null],

    phoneNumber: [null],

    email: [null, Validators.email],

    userID: [null],

    accountID: [null],

  });

  get isUpdate(): boolean {
    return !!this.id;
  }

  ngOnInit(): void {

    this.route.params.subscribe(params => {

      this.id = params['id'] ?? null;

      if (this.isUpdate) {
        this.loadLead();
      }

    });

    this.userService.getList({
      maxResultCount: 999
    }).subscribe(res => {

      this.users = res.items;

    });
    this.accountService.getList({maxResultCount:999}).subscribe(
      res => {
        this.accounts = res.items;
      }
    )
  }

  private loadLead(): void {

    this.leadsService.get(this.id!).subscribe(dto => {

      this.form.patchValue(dto);

    });

  }

  submit(): void {

    const dto = this.form.value as CreateUpdateLeadDto;

    if (!this.isUpdate) {

      this.leadsService.create(dto).subscribe(res => {

        this.toaster.success(
          res.id,
          '::Lead:Created:Successfully'
        );

      });

    } else {

      this.leadsService.update(this.id!, dto).subscribe(res => {

        this.toaster.success(
          res.id,
          '::Lead:Updated:Successfully'
        );

      });

    }

  }

}
// @Component({
//   selector: 'app-lead-form',
//   imports: [],
//   templateUrl: './lead-form.html',
//   styleUrl: './lead-form.scss',
// })
// export class LeadFormComponent {

// }
