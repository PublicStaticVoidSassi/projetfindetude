import {
  Component,
  forwardRef,
  inject,
  OnInit,
  Input
} from '@angular/core';

import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormsModule,
} from '@angular/forms';

// import {
//   IdentityUserDto,
//   IdentityUserService,
// } from '@abp/ng.identity/proxy';
import {
  LocalizationPipe
} from '@abp/ng.core';
import { LeadDto, LeadsService } from 'src/app/proxy/leads';

@Component({
  selector: 'leads-lookup',
  imports: [FormsModule,LocalizationPipe],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => LeadsLookup),
      multi: true,
    },
  ],

  template: `
  <div class="form-group mb-3">
            <label>{{ '::Assignto:lead' | abpLocalization }}</label>

    <select
      class="form-select"
      [ngModel]="value"
      (ngModelChange)="onSelect($event)"
      [disabled]="disabled"
    >
      <option [value]="null" >{{ '::Assignto:lead' | abpLocalization }}</option>

      @for (user of leads; track user.id) {
        <option [value]="user.id">
          {{user.firstName}} {{user.lastName}}
        </option>
      }
    </select>
    </div>
  `,
})
export class LeadsLookup
  implements ControlValueAccessor, OnInit
{
  @Input() id: string | null = null;
  @Input() disabled: boolean = false;
  leads: LeadDto[] = [];

  value: string | null = null;

  private readonly leadsservice =
    inject(LeadsService);

  ngOnInit() {

    this.leadsservice
      .getList({ maxResultCount: 1000 })
      .subscribe(r => {
        this.leads = r.items ?? [];
        this.onSelect(this.id);
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
