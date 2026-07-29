import { provideAppInitializer, inject } from '@angular/core';
import { ReplaceableComponentsService } from '@abp/ng.core';
import { eThemeLeptonXComponents } from '@abp/ng.theme.lepton-x';
import { NewSidebar } from './new-sidebar';

function initSideBar() {
  const replaceableComponents = inject(ReplaceableComponentsService);
  replaceableComponents.add({
    key: eThemeLeptonXComponents.Navbar,
    component: NewSidebar,
  });
}

export const SIDEBAR_PROVIDER = [
  provideAppInitializer(() => {
    initSideBar();
  }),
];
