import { ChangeDetectionStrategy, Component, inject } from '@angular/core';

import { Add } from './pages/add';
import { List } from './pages/list';
import { LinksStore } from './services/links-store';

@Component({
  selector: 'app-links',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [List, Add],
  providers: [LinksStore],
  template: `
    @if (store.isLoading()) {
      <span class="loading loading-spinner text-primary"></span>
      <span class="loading loading-spinner text-secondary"></span>
      <span class="loading loading-spinner text-accent"></span>
      <span class="loading loading-spinner text-neutral"></span>
      <span class="loading loading-spinner text-info"></span>
      <span class="loading loading-spinner text-success"></span>
      <span class="loading loading-spinner text-warning"></span>
      <span class="loading loading-spinner text-error"></span>
    } @else {
      <div>
        <h2 class="text-2xl font-bold">
          Your One Stop Shop For All Things Links
        </h2>
      </div>

      <div class="flex flex-row">
        <div class="w-1/2">
          <app-links-list />
        </div>
        <div class="w-1/3">
          <app-links-add />
        </div>
      </div>
    }
  `,
  styles: ``,
})
export class Links {
  store = inject(LinksStore);
}
