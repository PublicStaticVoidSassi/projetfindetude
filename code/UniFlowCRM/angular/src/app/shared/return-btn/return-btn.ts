import { Component } from '@angular/core';
import { LocalizationPipe } from '@abp/ng.core';
@Component({
  selector: 'app-return-btn',
  imports: [LocalizationPipe],
  template: `<button class="btn btn-secondary btn-sm me-2" (click)="goBack()">
          <i class="fa fa-arrow-left me-1"></i>
          {{ '::Back' | abpLocalization }}
        </button>`,
})
export class ReturnBtn {
goBack(): void {
  history.back();
}
}
