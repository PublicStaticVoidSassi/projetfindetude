import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { LocalizationPipe } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { saleStageOptions } from '../../proxy/opportunities/sale-stage.enum'
import { currencyOptions } from '../../proxy/moneys/currency.enum'
import { ReturnBtn } from '../../shared/return-btn/return-btn';
// import { enumToDropdown } from '../../shared/enum-to-dropdown';
import { Currency } from '../../proxy/moneys';

import { AccountsLookup, ContactsLookup, LeadsLookup, OpportunitiesLookup } from '../../shared/lookup-components/';
import {
  OpportunitiesService,
  CreateUpdateOpportunityDto,
  OpportunityStage,
  OpportunityType,
  SaleStage, opportunityTypeOptions
} from '../../proxy/opportunities';
import { opportunityStageOptions } from '../../proxy/opportunities/opportunity-stage.enum'
import { IdentityUserDto, IdentityUserService } from '@abp/ng.identity/proxy';
import { LeadsService, LeadDto } from '../../proxy/leads';
import { AccountsService, AccountDto } from '../../proxy/accounts';
import { ContactDto, ContactsService } from '../../proxy/contacts';
@Component({
  selector: 'app-opportunity-form',
  standalone: true,
  imports: [AccountsLookup, ContactsLookup, LeadsLookup,
    ReturnBtn,
    ReactiveFormsModule,
    LocalizationPipe
  ],
  templateUrl: './opportunity-form.html',
  styleUrl: './opportunity-form.scss',
})
export class OpportunityFormComponent implements OnInit {

  private fb = inject(FormBuilder);

  private route = inject(ActivatedRoute);

  private service = inject(OpportunitiesService);
  private userService = inject(IdentityUserService);
  private leadService = inject(LeadsService);
  private accountService = inject(AccountsService);
  private contactService = inject(ContactsService);
  private toaster = inject(ToasterService);
  private router = inject(Router);

  OpportunityStage = opportunityStageOptions;
  types = opportunityTypeOptions;
  saleStages = saleStageOptions;
  currencies = currencyOptions;
  id: string | null = null;

  users: IdentityUserDto[] = [];
  leads: LeadDto[] = [];
  accounts: AccountDto[] = [];
  contacts: ContactDto[] = [];
  // stages = enumToDropdown(OpportunityStage);

  form: FormGroup = this.fb.group({
    name: ['', Validators.required],
    description: [null],
    amountCurrency: [Currency.DZD],
    amountValue: [0],
    stage: [OpportunityStage.Prospecting, Validators.required],
    type: [OpportunityType.NewBusiness, Validators.required],
    probability: [50],
    nextStep: [null],
    closedAt: [null],
    userID: [null, Validators.required],
    leadID: [this.route.snapshot.queryParamMap.get('leadID')],
    accountID: [this.route.snapshot.queryParamMap.get('accountID')],
    contactID: [this.route.snapshot.queryParamMap.get('contactID')],
  });

  get isUpdate(): boolean {
    return !!this.id;
  }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      this.id = params['id'] ?? null;
      if (this.isUpdate) this.load();
    });

    this.userService.getList({ maxResultCount: 999 }).subscribe(r => this.users = r.items);
    this.leadService.getList({ maxResultCount: 999 }).subscribe(r => this.leads = r.items);
    this.accountService.getList({ maxResultCount: 999 }).subscribe(r => this.accounts = r.items);
    this.contactService.getList({ maxResultCount: 999 })
      .subscribe(r => this.contacts = r.items);
    setTimeout(() => {
      this.form.patchValue({
        leadID: this.route.snapshot.queryParamMap.get('leadID'),
        accountID: this.route.snapshot.queryParamMap.get('accountID'),
        contactID: this.route.snapshot.queryParamMap.get('contactID'),
      });
    }, 1000);

  }

  private load(): void {
    this.service.get(this.id!).subscribe(dto => {
      setTimeout(() => {

        this.form.patchValue(dto);
      }, 1000);
    });
  }

  submit(): void {

    const dto = this.form.value as CreateUpdateOpportunityDto;

    if (!this.isUpdate) {

      this.service.create(dto).subscribe(res => {
        this.toaster.success(res.id, '::Opportunity:Created:Successfully');
        this.router.navigate(['Opportunities', res.id]);
      });

    } else {

      this.service.update(this.id!, dto).subscribe(res => {
        this.toaster.success(res.id, '::Opportunity:Updated:Successfully');
        this.router.navigate(['Opportunities', res.id]);
      });

    }
  }

  protected readonly opportunityStageOptions = opportunityStageOptions;
}
