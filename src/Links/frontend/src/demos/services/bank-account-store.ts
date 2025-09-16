import { computed } from '@angular/core';
import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withProps,
  withState,
} from '@ngrx/signals';

const WITHDRAWAL_AMOUNTS = [5, 10, 20, 50, 100, 500, 1000] as const;
type BankAccountState = {
  balance: number;
  minimumWithdrawalAmount: number;
  plannedWithdrawal: number;
};

type WithdrawalAmount = (typeof WITHDRAWAL_AMOUNTS)[number];
export const BankAccountStore = signalStore(
  withState<BankAccountState>({
    balance: 500,
    minimumWithdrawalAmount: 20,
    plannedWithdrawal: 0,
  }),
  withMethods((store) => {
    return {
      reset: () => patchState(store, { plannedWithdrawal: 0 }),
      addAmount: (amount: WithdrawalAmount) =>
        patchState(store, {
          plannedWithdrawal: store.plannedWithdrawal() + amount,
        }),
    };
  }),
  withComputed((store) => {
    return {
      amountLeft: computed(() => store.balance() - store.plannedWithdrawal()),
    };
  }),
  withProps(() => ({
    amounts: WITHDRAWAL_AMOUNTS,
  })),
  withHooks({
    onInit() {
      // maybe go to the API and get THIS user's balance?
      console.log('Just created an instance of the BankAccountStore');
    },
    onDestroy() {
      console.log('Destroying an instance of the BankAccountStore');
    },
  }),
);
