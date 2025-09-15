import { Component, ChangeDetectionStrategy, input } from '@angular/core';
import { NavLink } from './types';

@Component({
  selector: 'app-nav-link',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <a class="link p-2" href="{{ link().href }}">{{ link().label }}</a>
  `,
  styles: ``,
})
export class NavBarLink {
  link = input.required<NavLink>();
}
