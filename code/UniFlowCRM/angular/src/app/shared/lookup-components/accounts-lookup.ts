import {
  Component,
  forwardRef,
  inject,
  OnInit,
} from '@angular/core';

import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormsModule,
} from '@angular/forms';
import {
  LocalizationPipe
} from '@abp/ng.core';
import { LeadDto, LeadsService } from 'src/app/proxy/leads';
import { AccountDto, AccountsService } from 'src/app/proxy/accounts';

@Component({
  selector: 'accounts-lookup',
  imports: [FormsModule,LocalizationPipe],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AccountsLookup),
      multi: true,
    },
  ],

  template: `
  <div class="form-group mb-3">
            <label>{{ '::Assignto:Account' | abpLocalization }}</label>
          
    <select
      class="form-select"
      [ngModel]="value"
      (ngModelChange)="onSelect($event)"
    >
      <option [ngValue]="null">{{ '::Assignto:Account' | abpLocalization }}</option>

      @for (user of accounts; track user.id) {
        <option [value]="user.id">
          {{user.name}}
        </option>
      }
    </select>
    </div>
  `,
})
export class AccountsLookup
  implements ControlValueAccessor, OnInit
{
  accounts: AccountDto[] = [];

  value: string | null = null;

  private readonly accountsservice =
    inject(AccountsService);

  ngOnInit() {
    this.accountsservice
      .getList({ maxResultCount: 1000 })
      .subscribe(r => {
        this.accounts = r.items ?? [];
      });
  }

  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(value: string | null): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onSelect(value: string | null) {
    this.value = value;
    this.onChange(value);
    this.onTouched();
  }
}