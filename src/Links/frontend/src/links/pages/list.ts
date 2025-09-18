import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { LinksStore } from '../services/links-store';

@Component({
  selector: 'app-links-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [DatePipe],
  template: `
    <div class="join">
      <button
        (click)="store.setSortOption('newestFirst')"
        [disabled]="store.sortOption() === 'newestFirst'"
        class="btn btn-ghost join-item"
      >
        Newest First
      </button>
      <button
        (click)="store.setSortOption('oldestFirst')"
        [disabled]="store.sortOption() === 'oldestFirst'"
        class="btn btn-ghost join-item"
      >
        Oldest First
      </button>
    </div>
    <ul>
      @for (link of store.sortedLinks(); track link.id) {
        <li class="card bg-base-100 card-xl shadow-sm pb-4">
          <div class="card-body">
            <h2 class="card-title">{{ link.title }}</h2>
            <p>{{ link.description }}</p>
            <p>
              Submitted by: <span>{{ link.addedBy }}</span>
            </p>
            <p>
              Submitted on: <span>{{ link.created | date: 'medium' }}</span>
            </p>
            <div class="justify-end card-actions">
              <a [href]="link.href" target="_blank" class="btn btn-primary"
                >Visit {{ link.href }}</a
              >
            </div>
          </div>
        </li>
      } @empty {
        <div class="alert alert-info">
          There are no Links! Sorry! Check Back Later!
        </div>
      }
    </ul>
  `,
  styles: ``,
})
export class List {
  // TODO: one super fake classroom thing incoming, but I will fix this later, I promise.
  store = inject(LinksStore);
}
