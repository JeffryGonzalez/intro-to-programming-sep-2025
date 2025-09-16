import { CurrencyPipe } from '@angular/common';
import {
  Component,
  ChangeDetectionStrategy,
  signal,
  computed,
  inject,
} from '@angular/core';
import { BankAccountStore } from '../services/bank-account-store';

@Component({
  selector: 'app-demos-atm-withdraw',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CurrencyPipe],
  providers: [BankAccountStore],
  template: `
    <p class="text-2xl font-bold">
      Your Current Balance is {{ store.balance() | currency }}
    </p>

    <div class="flex gap-4">
      @for (amount of store.amounts; track $index) {
        <button
          [disabled]="store.amountLeft() - amount < 0"
          (click)="store.addAmount(amount)"
          class="btn btn-success"
        >
          {{ amount }}
        </button>
      }
    </div>

    <div>
      <p>You want to withdraw: {{ store.plannedWithdrawal() | currency }}</p>
    </div>
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
export class AtmWithdraw {
  store = inject(BankAccountStore); // the same as the constructor on our BankAccount(ICanCalculateBonuses )
}
