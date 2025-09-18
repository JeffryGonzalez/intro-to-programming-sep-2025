import { Routes } from '@angular/router';
import { Links } from './links';
import { List } from './pages/list';
import { Add } from './pages/add';
export const LINKS_ROUTES: Routes = [
  {
    path: '',
    component: Links,
    children: [
      {
        path: 'list',
        component: List,
      },
      {
        path: 'add',
        component: Add,
      },
    ],
  },
];
