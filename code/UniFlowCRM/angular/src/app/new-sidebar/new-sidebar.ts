import { Component, inject, OnInit, provideAppInitializer } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalizationPipe, ReplaceableComponentsService, RoutesService } from '@abp/ng.core';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { eThemeLeptonXComponents } from '@abp/ng.theme.lepton-x';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-new-sidebar',
  imports: [
    AsyncPipe,
    RouterLink,
    LocalizationPipe
  ],
  templateUrl: './new-sidebar.html'
})
export class NewSidebar implements OnInit {
  public menuItems$: Observable<Array<any>>;
  private readonly routesService = inject(RoutesService);
ngOnInit() {
  this.menuItems$ = this.routesService.visible$;
}

}









function replaceSideBar() {
  const replaceableComponents = inject(ReplaceableComponentsService);

  replaceableComponents.add({
    key: eThemeLeptonXComponents.Navbar,
    component: NewSidebar // remove
  })
}

export const REPLACE_SIDEBAR = [
  provideAppInitializer(() => {
    replaceSideBar();
  }),
];
