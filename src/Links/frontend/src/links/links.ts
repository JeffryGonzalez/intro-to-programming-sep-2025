import { Component, ChangeDetectionStrategy } from '@angular/core';
import { List } from './pages/list';
import { Add } from './pages/add';

@Component({
  selector: 'app-links',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [List, Add],
  template: `
    <p>Links Will Go Here</p>

    <app-links-add />
    <app-links-list />
  `,
  styles: ``,
})
export class Links {}
