import {
  ApplicationConfig,
  provideZonelessChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import { provideHttpClient, withFetch } from '@angular/common/http';
import { routes } from './app.routes';
import { BankAccountStore } from '../demos/services/bank-account-store';

export const appConfig: ApplicationConfig = {
  providers: [
    BankAccountStore, // "A Singleton(?) of this."
    provideZonelessChangeDetection(),
    provideRouter(routes),
    provideHttpClient(withFetch()),
  ],
};
