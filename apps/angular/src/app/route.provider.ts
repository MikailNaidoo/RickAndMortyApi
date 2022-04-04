import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/products',
        name: 'ProductService::Menu:Products',
        iconClass: 'fas fa-book',
        order: 3,
        layout: eLayoutType.application,
        requiredPolicy: 'ProductService.Products',
      },
      {
        path: '/characters',
        name: 'CharacterService::Menu:Characters',
        iconClass: 'fas fa-user',
        order: 4,
        layout: eLayoutType.application,
        requiredPolicy: 'CharacterService.Characters',
      },
    ]);
  };
}
