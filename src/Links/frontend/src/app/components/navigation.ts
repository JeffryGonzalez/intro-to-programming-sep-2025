import {
  Component,
  ChangeDetectionStrategy,
  signal,
  computed,
} from '@angular/core';
import { NavLink } from './types';
import { NavBarLink } from './nav-link';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-navigation',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [NavBarLink, RouterLink],
  template: `
    <div class="navbar bg-base-100 shadow-sm">
      <div class="navbar-start">
        <div class="dropdown">
          <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="h-5 w-5"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M4 6h16M4 12h8m-8 6h16"
              />
            </svg>
          </div>
          <ul
            tabindex="0"
            class="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
          >
            @for (link of links(); track link.href) {
              <app-nav-link
                (linkClicked)="onLinkClicked($event)"
                [link]="link"
              />
            }
          </ul>
        </div>

        <a routerLink="/" class="btn btn-ghost text-xl">Into to Programming</a>
      </div>
      <div class="navbar-center hidden lg:flex">
        <ul class="menu menu-horizontal px-1">
          @for (link of links(); track link.href) {
            <app-nav-link
              [decoration]="getDecoration()"
              (linkClicked)="onLinkClicked($event)"
              [link]="link"
            />
          }
        </ul>
      </div>
      <div class="navbar-end">
        <span>(You are at {{ current() }})</span>
        <a class="btn">Button</a>
      </div>
    </div>
  `,
  styles: ``,
})
export class Navigation {
  current = signal('');

  getDecoration = computed(() => (this.current() === 'Home' ? '*' : ''));
  onLinkClicked(path: string) {
    this.current.set(path);
  }
  links = signal<NavLink[]>([
    {
      href: '/',
      label: 'Home',
    },
    {
      href: '/demos',
      label: 'Demos',
    },
    {
      href: '/links',

      label: 'Links',
    },
    {
      href: '/support',
      label: 'Support',
    },
  ]);
}
