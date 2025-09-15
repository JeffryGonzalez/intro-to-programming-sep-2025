import { Component } from '@angular/core';
import { Navigation } from './components/navigation';

@Component({
  selector: 'app-root',
  template: `
    <app-navigation />

    <main>
      <p>Our Stuff Goes here</p>
    </main>
  `,
  styles: [],
  imports: [Navigation],
})
export class App {}
