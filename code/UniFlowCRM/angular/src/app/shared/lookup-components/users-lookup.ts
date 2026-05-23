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
  IdentityUserDto,
  IdentityUserService,
} from '@abp/ng.identity/proxy';
import {
  LocalizationPipe
} from '@abp/ng.core';

@Component({
  selector: 'users-lookup',
  imports: [FormsModule,LocalizationPipe],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => UsersLookup),
      multi: true,
    },
  ],

  template: `
  <div class="form-group mb-3">
            <label>{{ '::Assignto:Owner' | abpLocalization }}</label>
          
    <select
      class="form-select"
      [ngModel]="value"
      (ngModelChange)="onSelect($event)"
    >
      <option [ngValue]="null">{{ '::Assignto:Owner' | abpLocalization }}</option>

      @for (user of users; track user.id) {
        <option [value]="user.id">
          {{ user.userName }}
        </option>
      }
    </select>
    </div>
  `,
})
export class UsersLookup
  implements ControlValueAccessor, OnInit
{
  users: IdentityUserDto[] = [];

  value: string | null = null;

  private readonly identityUserService =
    inject(IdentityUserService);

  ngOnInit() {
    this.identityUserService
      .getList({ maxResultCount: 1000 })
      .subscribe(r => {
        this.users = r.items ?? [];
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