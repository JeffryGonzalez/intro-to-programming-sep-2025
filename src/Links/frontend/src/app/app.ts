import { Component } from '@angular/core';
import { Navigation } from './components/navigation';

@Component({
  selector: 'app-root',
  template: ` <app-navigation /> `,
  styles: [],
  imports: [Navigation],
})
export class App {}
