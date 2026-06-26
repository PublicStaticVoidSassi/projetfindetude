import { Component, inject, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'create-opp-btn',
  imports: [],
  template: `
<button class="btn btn-sm btn-brand me-2" (click)="redirect()">
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
