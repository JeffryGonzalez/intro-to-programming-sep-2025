import {
  Component,
  ChangeDetectionStrategy,
  input,
  output,
} from '@angular/core';
import { NavLink } from './types';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav-link',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, RouterLinkActive],
  template: `
    <a
      class="link px-2 "
      [routerLinkActive]="['font-bold', 'text-accent']"
      [routerLinkActiveOptions]="{ exact: true }"
      [routerLink]="link().href"
      (click)="linkClicked.emit(link().label)"
      >{{ link().label }}{{ decoration() }}</a
    >
  `,
  styles: ``,
})
export class NavBarLink {
  link = input.required<NavLink>();
  decoration = input<string>('');
  linkClicked = output<string>();
}
