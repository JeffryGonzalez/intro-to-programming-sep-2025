import { Component, ChangeDetectionStrategy } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-demos',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, RouterLink],
  template: `
    <div class="flex flex-row">
      <div>
        <div class="flex flex-col gap-2">
          <a routerLink="signals" class="btn btn-primary">Signals 101</a>
          <a routerLink="effects" class="btn btn-primary">Effects</a>
          <a routerLink="services" class="btn btn-primary">Services</a>
        </div>
      </div>
      <div class="px-4"><router-outlet /></div>
    </div>
  `,
  styles: ``,
})
export class Demos {}
