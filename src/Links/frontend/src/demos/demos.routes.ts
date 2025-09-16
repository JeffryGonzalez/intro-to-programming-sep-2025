import { Routes } from '@angular/router';
import { Demos } from './demos';
import { Effects } from './pages/effects';
import { Services } from './pages/services';
import { Signals } from './pages/signals';

export const DEMOS_ROUTES: Routes = [
  {
    path: '', // /demos/
    component: Demos,
    providers: [],
    children: [
      {
        path: 'signals',
        component: Signals,
      },
      {
        path: 'effects',
        component: Effects,
      },
      {
        path: 'services',
        component: Services,
      },
    ],
  },
];
