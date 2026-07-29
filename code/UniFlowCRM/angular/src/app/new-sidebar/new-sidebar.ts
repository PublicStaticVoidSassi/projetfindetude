import { Component, inject, Injector, OnInit, PLATFORM_ID, provideAppInitializer, TemplateRef } from '@angular/core';
import { map as map$1, Observable } from 'rxjs';
import { LocalizationPipe, ReplaceableComponentsService, RoutesService } from '@abp/ng.core';
import { AsyncPipe, isPlatformBrowser, NgComponentOutlet, NgTemplateOutlet } from '@angular/common';
import { RouterLink } from '@angular/router';
import { eThemeLeptonXComponents } from '@abp/ng.theme.lepton-x';
import { FooterComponent } from '../footer/footer.component';
import {
  NavbarComponent, LayoutService, NavbarService, NavbarRoutesComponent, CONTENT_BEFORE_ROUTES, CONTENT_AFTER_ROUTES,
  BrandLogoComponent, IconComponent
} from '@volo/ngx-lepton-x.core';
import * as i0 from '@angular/core';

@Component({
  selector: 'app-new-sidebar',
  imports: [
    AsyncPipe,
    // RouterLink,
    // LocalizationPipe,
    NavbarRoutesComponent,
    // NavbarComponent,
    BrandLogoComponent,
    IconComponent,
    NgComponentOutlet,
    NgTemplateOutlet
  ],
template: `
  <div class="kt-sidebar lpx-nav">
<!--    <div class="kt-sidebar-header bg-danger lg:flex items-center relative justify-between px-3 lg:px-6 shrink-0" id="sidebar_header">-->
<!--      -->
<!--    </div>-->
<!--    <button class="kt-btn kt-btn-outline kt-btn-icon" (click)="toggleSidebar()" [class.active]="buttonActive" data-kt-toggle="body" data-kt-toggle-class="kt-sidebar-collapse" id="sidebar_toggle" data-kt-toggle-initialized="true">-->
<!--      <i class="ki-filled ki-black-left-line kt-toggle-active:rotate-180 transition-all duration-300 rtl:translate rtl:rotate-180 rtl:kt-toggle-active:rotate-0">-->
<!--      </i>-->
<!--    </button>-->
      <div class="lpx-logo-container d-block">
        <ng-container *ngTemplateOutlet="defaultLogo" ></ng-container>
        <!--            <lpx-icon class="menu-collapse-icon hidden-in-hover-trigger" iconClass="bi bi-filter-left" (click)="toggleSidebarHover()"></lpx-icon>-->
        <button class="kt-btn kt-btn-outline kt-btn-icon hidden-in-hover-trigge" (click)="toggleSidebar()" [class.active]="buttonActive" data-kt-toggle="body" data-kt-toggle-class="kt-sidebar-collapse" id="sidebar_toggle" data-kt-toggle-initialized="true">
          <i class="ki-filled ki-black-left-line kt-toggle-active:rotate-180 transition-all duration-300 rtl:translate rtl:rotate-180 rtl:kt-toggle-active:rotate-0">
          </i>
        </button>
      </div>



    <div class="lpx-nav kt-sidebar-content flex grow shrink-0" id="sidebar_content">
              <ng-container *ngTemplateOutlet="defaultRouteTemplate; context: { $implicit: service.navbarItems$ | async, groupItems: service.groupedNavbarItems$ | async, } " ></ng-container>

    </div>
  </div>

<!--    default start-->
<!--    <nav class="lpx-nav" (mouseenter)="handleInitialHover()">-->
<!--      <div class="lpx-logo-container">-->
<!--        <ng-container *ngTemplateOutlet="defaultLogo" ></ng-container>-->
<!--        <lpx-icon class="menu-collapse-icon hidden-in-hover-trigger" iconClass="bi bi-filter-left" (click)="toggleSidebarHover()"></lpx-icon>-->
<!--      </div>-->

<!--        <ng-container *ngTemplateOutlet="defaultRouteTemplate; context: { $implicit: service.navbarItems$ | async, groupItems: service.groupedNavbarItems$ | async, } " ></ng-container>-->
<!--    </nav>-->
<!--default end-->

<!--    INIT DEFAULT ROUTE TEMPLATE START  -->
    <ng-template #defaultRouteTemplate let-items let-groupItems="groupItems">
      <lpx-navbar-routes [navbarItems]="items" [groupedItems]="groupItems" [routerItem]="true"></lpx-navbar-routes>
    </ng-template>
<!--    INIT DEFAULT ROUTE TEMPLATE END   -->


    <!--  INIT LOGO START  -->
    <ng-template #defaultLogo>
      <lpx-brand-logo />
    </ng-template>
    <!--  INIT LOGO END-->
  `
})
export class NewSidebar {
  layoutService = inject(LayoutService);
  platformId = inject(PLATFORM_ID);
  service = inject(NavbarService);
  injector = inject(Injector);
  didResized = false;
  initialHover = false;
  showFilterMenu$ = this.service.sourceNavbarItems$.pipe(map$1((items) => !!items.length));
  contentBefore = this.flatContents(CONTENT_BEFORE_ROUTES);
  contentAfter = this.flatContents(CONTENT_AFTER_ROUTES);
  protected collapsed: boolean = false; // NEW

  toggleSidebarHover() {
    this.didResized = true;
    this.layoutService.toggleClass('hover-trigger');
    this.initialHover = !this.initialHover;
    if (this.initialHover) {
      this.layoutService.addClass('initial-hover');
    }
    else {
      this.layoutService.removeClass('initial-hover');
    }
  }
  handleInitialHover() {
    if (this.initialHover) {
      this.layoutService.removeClass('initial-hover');
    }
  }
  ngAfterViewChecked() {
    if (!isPlatformBrowser(this.platformId)) {
      return;
    }
    if (this.didResized) {
      this.didResized = false;
      window.dispatchEvent(new Event('resize'));
    }
  }
  flatContents(token) {
    const contents = this.injector.get(token, []);
    return contents.reduce((acc, val) => acc.concat(val), []);
  }

// new
  protected buttonActive: boolean = false;
  protected toggleSidebar() {
    this.buttonActive = !this.buttonActive;
    this.collapsed = !this.collapsed;
    this.toggleSidebarHover();
  }
}
