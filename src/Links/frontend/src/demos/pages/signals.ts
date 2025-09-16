import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AtmWithdraw } from '../component/atm-withdraw';

@Component({
  selector: 'app-demos-signals',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [AtmWithdraw],
  template: ` <app-demos-atm-withdraw /> `,
  styles: ``,
})
export class Signals {}
