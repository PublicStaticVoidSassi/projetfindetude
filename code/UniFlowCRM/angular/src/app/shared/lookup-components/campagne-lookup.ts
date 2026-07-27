import {
  Component,
  forwardRef,
  inject, Input,
  OnInit
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
import { CampaignDto, CampaignService } from '../../proxy/campaigns';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'campaigns-lookup',
  imports: [FormsModule,LocalizationPipe],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CampaignsLookup),
      multi: true,
    },
  ],

  template: `
    <div class="form-group mb-3">
      <label class="form-label">{{ 'Depuis le campagne' }}</label>

      <select
        [disabled]="disabled"
        class="form-select"
        [ngModel]="value"
        (ngModelChange)="onSelect($event)"

      >

        @for (user of campagnes; track user.id) {
          <option [value]="user.id">
            {{ user.name }}
          </option>
        }
      </select>
    </div>
  `,
})
export class CampaignsLookup
  implements ControlValueAccessor, OnInit
{
  campagnes: CampaignDto[] = [];
  @Input() id: string | null = null;
  @Input() disabled: boolean = false;
  value: string | null = null;

  private readonly campagneService =
    inject(CampaignService);

  ngOnInit() {
    this.campagneService
      .getLookup()
      .subscribe(r => {
        this.campagnes = r ?? [];
        this.value = this.id;
        this.writeValue(this.value)
        this.onSelect(this.value);
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
