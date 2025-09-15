import { Routes } from '@angular/router';
import { Demos } from './demos';
import { Signals } from './pages/signals';
import { Effects } from './pages/effects';
import { Services } from './pages/services';
export const DEMOS_ROUTES: Routes = [
  {
    path: '',
    component: Demos,
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
