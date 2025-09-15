import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-home',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div class="prose">
      <h2>Intro to Programming - Angular Sample Application</h2>
    </div>
  `,
  styles: ``,
})
export class Home {}
