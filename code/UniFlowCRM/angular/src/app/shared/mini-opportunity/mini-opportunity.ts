import { Component, inject, Input } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionDirective } from '@abp/ng.core';

@Component({
  selector: 'create-opp-btn',
  imports: [
    PermissionDirective
  ],
  template: `
<button *abpPermission='"UniFlowCRM.Opportunity.Create"' class="btn btn-sm btn-brand me-2" (click)="redirect()">
créer une opportunités
</button>
`
})
export class MiniOpportunity {
  private router = inject(Router);

  redirect() {
    this.router.navigate(['Opportunities', 'form'], {
      queryParams: {
        [`${this.for}ID`]: this.id
      }
    });
  }
  @Input() for!: 'lead' | 'contact' | 'account';
  @Input() id!: string;
}
