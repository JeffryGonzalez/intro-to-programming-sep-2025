import { Component, ChangeDetectionStrategy } from '@angular/core';

import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-links',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, RouterOutlet],
  template: `
    <div>
      <h2 class="text-2xl font-bold">
        Your One Stop Shop For All Things Links
      </h2>
    </div>
    <div class="flex flex-row gap2">
      <a class="btn btn-sm btn-ghost" [routerLink]="['add']">Add A Link</a>
      <a class="btn btn-sm btn-ghost" [routerLink]="['list']">View Links</a>
    </div>
    <router-outlet />
  `,
  styles: ``,
})
export class Links {}
