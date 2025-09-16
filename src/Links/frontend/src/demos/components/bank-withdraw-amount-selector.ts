import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { BankAccountStore } from '../services/bank-account-store';

@Component({
  selector: 'app-demo-bank-withdraw-amount-selector',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  providers: [],
  template: `
    <div class="join">
      @for (amount of store.amounts; track $index) {
        <button
          [disabled]="store.amountLeft() - amount < 0"
          (click)="store.addAmount(amount)"
          class="join-item btn btn-success"
        >
          {{ amount }}
        </button>
      }
    </div>
  `,
  styles: ``,
})
export class BankWithdrawAmountSelector {
  store = inject(BankAccountStore);
}
