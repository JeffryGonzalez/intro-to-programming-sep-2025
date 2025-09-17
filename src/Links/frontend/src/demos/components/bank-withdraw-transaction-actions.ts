import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { BankAccountStore } from '../../shared/services/bank-account-store';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-demo-bank-withdraw-transaction-actions',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CurrencyPipe],
  template: `
    <div>
      @if (store.plannedWithdrawal() > 0) {
        <button (click)="store.reset()" class="btn btn-warning">Cancel</button>

        @if (store.plannedWithdrawal() >= store.minimumWithdrawalAmount()) {
          <button class="btn btn-success">
            Make Withdrawal of {{ store.plannedWithdrawal() | currency }}
          </button>
        } @else {
          <p>
            This bank only allows withdrawals of
            {{ store.minimumWithdrawalAmount() | currency }} or more.
          </p>
        }
      }
    </div>
  `,
  styles: ``,
})
export class BankWithdrawTransactionActions {
  store = inject(BankAccountStore);
}
