// account-form.component.ts
import {enumToDropdown} from '../../shared/enum-to-dropdown';
import {ReturnBtn} from '../../shared/return-btn/return-btn';
import { IdentityUserDto, IdentityUserService } from '@abp/ng.identity/proxy';
import { Component,inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
// import  {Accounts} from '../../proxy';
import { accountTypeOptions,accountIndustryOptions, AccountType,AccountIndustry,CreateUpdateAccountDto } from '../../proxy/accounts';
// import { AccountType } from './account-type.enum';
import { Currency, currencyOptions } from '../../proxy/moneys';
import {LocalizationPipe} from '@abp/ng.core';
import { AccountsService } from '../../proxy/accounts/accounts.service';
import { ToasterService } from '@abp/ng.theme.shared';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersLookup } from '../../shared/lookup-components';
// import { AccountIndustry } from '../../proxy/accounts/account-industry.enum';
// enum AccountType = Accounts.AccountType;

@Component({
  selector: 'app-account-form',
  templateUrl: './account-form.html',
  imports: [ReturnBtn, ReactiveFormsModule, LocalizationPipe, ReturnBtn, UsersLookup]
})
export class AccountFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private userService = inject(IdentityUserService);
  private accountsService = inject(AccountsService);
  private toaster = inject(ToasterService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  accountTypes = accountTypeOptions;
  accountIndustries = accountIndustryOptions;
  currencies = currencyOptions;

  users: IdentityUserDto[] = [];

  id: string | null = null;

  form: FormGroup = this.fb.group({
    name: ['', Validators.required],
    description: [null],

    phoneCode: [null],
    phoneNumber: [null],

    faxCode: [null],
    faxNumber: [null],

    email: [null, Validators.email],
    website: [null],

    city: [null],
    street: [null],
    country: [null],

    postalCode: [null],

    type: [AccountType.Customer],
    industry: [AccountIndustry.Other],

    revenueAmount: [0],
    revenueCurrency: [Currency.DZD],

    employees: [1],

    userID: [null, Validators.required],
  });

  get isUpdate(): boolean {
    return !!this.id;
  }

  ngOnInit(): void {
    // route handling
    this.route.params.subscribe(params => {
      this.id = params['id'] ?? null;

      if (this.isUpdate) {
        this.loadAccount();
      }
    });

    // users
    this.userService.getList({ maxResultCount: 999 }).subscribe(res => {
      this.users = res.items;
    });
  }

  private loadAccount(): void {
    this.accountsService.get(this.id!).subscribe(dto => {
      this.form.patchValue(dto);
    });
  }

  submit(): void {
    const dto = this.form.value as CreateUpdateAccountDto;

    if (!this.isUpdate) {
      this.accountsService.create(dto).subscribe(res => {
        this.toaster.success(res.id, '::Account:Created:Successfully');
        this.router.navigate(['/Accounts',res.id])
      });
    } else {
      this.accountsService.update(this.id!, dto).subscribe(res => {
        this.toaster.success(res.id, '::Account:Updated:Successfully');
      });
    }
  }
}
