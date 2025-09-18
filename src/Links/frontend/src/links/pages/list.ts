import { DatePipe } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  computed,
  resource,
  signal,
} from '@angular/core';

@Component({
  selector: 'app-links-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [DatePipe],
  template: `
    @if (linksResource.isLoading()) {
      <div class="alert alert-info">Chill out - loading your links.</div>
    } @else {
      <div class="join">
        <button
          (click)="sortOption.set('newestFirst')"
          [disabled]="sortOption() === 'newestFirst'"
          class="btn btn-ghost join-item"
        >
          Newest First
        </button>
        <button
          (click)="sortOption.set('oldestFirst')"
          [disabled]="sortOption() === 'oldestFirst'"
          class="btn btn-ghost join-item"
        >
          Oldest First
        </button>
      </div>
      <ul>
        @for (link of sortedLinks(); track link.id) {
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
    }
  `,
  styles: ``,
})
export class List {
  // TODO: one super fake classroom thing incoming, but I will fix this later, I promise.
  sortOption = signal<'newestFirst' | 'oldestFirst'>('newestFirst');
  linksResource = resource({
    loader: () => fetch('http://localhost:1337/links').then((r) => r.json()),
  });

  sortedLinks = computed(() => {
    const sortOption = this.sortOption();
    const links = this.linksResource.value() || [];
    return [...links].sort((a, b) => {
      const dateA = new Date(a.created).getTime();
      const dateB = new Date(b.created).getTime();
      if (sortOption === 'newestFirst') {
        return dateB - dateA;
      } else {
        return dateA - dateB;
      }
    });
  });
}
