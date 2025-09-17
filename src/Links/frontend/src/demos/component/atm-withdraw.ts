import { CurrencyPipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { BankAccountStore } from '../../shared/services/bank-account-store';
import { BankWithdrawAmountSelector } from '../components/bank-withdraw-amount-selector';
import { BankWithdrawTransactionActions } from '../components/bank-withdraw-transaction-actions';

@Component({
  selector: 'app-demos-atm-withdraw',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    CurrencyPipe,
    BankWithdrawAmountSelector,
    BankWithdrawTransactionActions,
  ],
  providers: [],
  template: `
    <p class="text-2xl font-bold">
      Your Current Balance is {{ store.balance() | currency }}
    </p>

    <app-demo-bank-withdraw-amount-selector />

    <div>
      <p>You want to withdraw: {{ store.plannedWithdrawal() | currency }}</p>
    </div>
    <app-demo-bank-withdraw-transaction-actions />
  `,
  styles: ``,
})
export class AtmWithdraw {
  store = inject(BankAccountStore); // the same as the constructor on our BankAccount(ICanCalculateBonuses )
}
