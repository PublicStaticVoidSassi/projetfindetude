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

// import {
//   IdentityUserDto,
//   IdentityUserService,
// } from '@abp/ng.identity/proxy';
import {
  LocalizationPipe
} from '@abp/ng.core';
import { LeadDto, LeadsService } from 'src/app/proxy/leads';
import { ContactDto, ContactsService } from 'src/app/proxy/contacts';

@Component({
  selector: 'contacts-lookup',
  imports: [FormsModule,LocalizationPipe],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ContactsLookup),
      multi: true,
    },
  ],

  template: `
  <div class="form-group mb-3">
            <label>{{ '::Assignto:Contact' | abpLocalization }}</label>

    <select
      class="form-select"
      [ngModel]="value"
      (ngModelChange)="onSelect($event)"
    >
      <option [ngValue]="null" disabled>{{ '::Assignto:Contact' | abpLocalization }}</option>

      @for (user of Contacts; track user.id) {
        <option [value]="user.id">
          {{user.firstName}} {{user.lastName}}
        </option>
      }
    </select>
    </div>
  `,
})
export class ContactsLookup
  implements ControlValueAccessor, OnInit
{
  Contacts: ContactDto[] = [];
  @Input() id: string | null = null;
  value: string | null = null;

  private readonly Contactsservice =
    inject(ContactsService);

  ngOnInit() {
    this.Contactsservice
      .getList({ maxResultCount: 1000 })
      .subscribe(r => {
        this.Contacts = r.items ?? [];
        this.writeValue(this.id===null?this.value:this.id);

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
