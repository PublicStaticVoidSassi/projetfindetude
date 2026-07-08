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
  ConfigStateService,
  LocalizationPipe, PermissionService
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
      [attr.disabled]="listdisabled"

    >
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
  private readonly permissionManager = inject(PermissionService);
  private readonly identityUserService =
    inject(IdentityUserService);
  private role = inject(ConfigStateService)
  listdisabled: boolean = false;
  isGuest():boolean {
    return !this.permissionManager.getGrantedPolicy("UniFlowCRM.AssignOthers");
    // return !this.role.getAll().currentUser.roles.includes("admin") && !this.role.getAll().currentUser.roles.includes("Directeur");
  }

  ngOnInit() {
    this.identityUserService
      .getList({ maxResultCount: 1000 })
      .subscribe(async r => {
        this.users = r.items ?? [];
        await new Promise(resolve => {setTimeout(resolve, 1000);});
        this.onSelect(this.role.getAll().currentUser.id);
        if (this.isGuest()){
          this.listdisabled = true;

        }
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
