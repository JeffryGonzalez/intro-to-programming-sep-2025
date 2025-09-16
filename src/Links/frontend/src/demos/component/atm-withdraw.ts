import { CurrencyPipe } from '@angular/common';
import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-demos-atm-withdraw',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CurrencyPipe],
  template: `
    <p class="text-2xl font-bold">
      Your Current Balance is {{ balance() | currency }}
    </p>

    <div class="flex gap-4">
      @for (amount of amounts; track $index) {
        <button (click)="addAmount(amount)" class="btn btn-success">
          {{ amount }}
        </button>
      }
    </div>

    <div>
      <p>You want to withdraw: {{ plannedWithdrawal() | currency }}</p>
    </div>
  `,
  styles: ``,
})
export class AtmWithdraw {
  // this will be fake, but play along.

  readonly amounts = [10, 20, 50, 100] as const;
  balance = signal(500);

  plannedWithdrawal = signal(0);

  addAmount(amount: number) {
    this.plannedWithdrawal.update((oldAmount) => oldAmount + amount);
    // or
    //this.plannedWithdrawal.set(this.plannedWithdrawal() + amount);
  }
}
