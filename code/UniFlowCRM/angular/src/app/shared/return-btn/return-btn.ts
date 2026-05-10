import { Component } from '@angular/core';

@Component({
  selector: 'app-return-btn',
  imports: [],
  template: `<button class="btn btn-sm btn-brand py-0 my-2" (click)="goBack()">
    <i class="fa fa-backward"></i>
    </button>`,
})
export class ReturnBtn {
goBack(): void {
  history.back();
}
}
