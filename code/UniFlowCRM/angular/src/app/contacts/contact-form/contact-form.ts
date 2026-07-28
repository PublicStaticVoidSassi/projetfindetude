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
  ContactStatus,
  ContactSource,
  CreateUpdateContactDto,
  contactStatusOptions,
  contactSourceOptions
} from '../../proxy/contacts';

import { LocalizationPipe, validateMinAge } from '@abp/ng.core';

import { ContactsService } from '../../proxy/contacts/contacts.service';
import { ToasterService, AbpVisibleDirective } from '@abp/ng.theme.shared';
import { ActivatedRoute, Router } from '@angular/router';

import { AccountDto, AccountsService } from 'src/app/proxy/accounts';
import { UsersLookup } from '../../shared/lookup-components';
import { CampaignsLookup } from '../../shared/lookup-components/campagne-lookup';
import { LeadSource } from '../../proxy/leads';

@Component({
  selector: 'app-contact-form',
  imports: [
    ReturnBtn,
    ReactiveFormsModule,
    LocalizationPipe,
    AbpVisibleDirective,
    UsersLookup,
    CampaignsLookup
  ],
  templateUrl: './contact-form.html',
})
export class ContactFormComponent implements OnInit {

  private fb = inject(FormBuilder);

  private userService = inject(IdentityUserService);
  private contactsService = inject(ContactsService);
  private accountService = inject(AccountsService);
  private toaster = inject(ToasterService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  contactStatuses = contactStatusOptions;
  contactSources = contactSourceOptions;

  users: IdentityUserDto[] = [];
  accounts: AccountDto[] = [];

  id: string | null = null;

  form: FormGroup = this.fb.group({

    firstName: ['', Validators.required],
    middleName: [null],
    lastName: [null],

    description: [null],

    status: [null,Validators.required],
    source: [null,Validators.required],

    phoneCode: [null],
    phoneNumber: [null],

    faxCode: [null],
    faxNumber: [null],

    email: [null, Validators.email],
    website: [null],

    country: [null],
    city: [null],
    street: [null],
    postalCode: [null],

    job: [null],
    departement: [null],

    userID: [null],
    // leadID: [null],
    accountID: [null],
    campaignId:[null],

  });

  get isUpdate(): boolean {
    return !!this.id;
  }

  ngOnInit(): void {

    this.route.params.subscribe(params => {

      this.id = params['id'] ?? null;

      if (this.isUpdate) {
        this.loadContact();
      }

    });

    this.userService.getList({ maxResultCount: 999 })
      .subscribe(res => this.users = res.items);

    this.accountService.getList({ maxResultCount: 999 })
      .subscribe(res => this.accounts = res.items);
  }

  private loadContact(): void {

    this.contactsService.get(this.id!).subscribe(dto => {
      this.form.patchValue(dto);
    });

  }

  submit(): void {

    const dto = this.form.value as CreateUpdateContactDto;

    if (!this.isUpdate) {

      this.contactsService.create(dto).subscribe(res => {
        this.toaster.success(res.id, '::Contact:Created:Successfully');
        this.router.navigate(['/Contacts',res.id])
      });

    } else {

      this.contactsService.update(this.id!, dto).subscribe(res => {
        this.toaster.success(res.id, '::Contact:Updated:Successfully');
      });

    }
  }

  protected readonly LeadSource = LeadSource;
  protected readonly ContactSource = ContactSource;
}
