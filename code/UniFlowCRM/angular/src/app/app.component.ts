import { Component, inject, OnInit } from '@angular/core';
import { AuthService, DynamicLayoutComponent } from '@abp/ng.core';
import { LoaderBarComponent } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar />
    <abp-dynamic-layout />
  `,
  imports: [LoaderBarComponent, DynamicLayoutComponent],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.auth.isAuthenticated || this.auth.navigateToLogin();
  }
  private auth = inject(AuthService);


}
