import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { LinkListItemModel } from '../types';
import {
  withEntities,
  setAllEntities,
  addEntity,
} from '@ngrx/signals/entities';
import { computed } from '@angular/core';
export type LinkCreateModel = Pick<
  LinkListItemModel,
  'title' | 'description' | 'href'
>;

type SortOptions = 'newestFirst' | 'oldestFirst';
type LinksState = {
  sortOption: SortOptions;
  _apiState: 'idle' | 'fetching' | 'error';
};
export const LinksStore = signalStore(
  withState<LinksState>({
    sortOption: 'newestFirst',
    _apiState: 'idle',
  }),
  withEntities<LinkListItemModel>(),
  withMethods((store) => {
    return {
      addLink: async (model: LinkCreateModel) => {
        await fetch('http://localhost:1337/links', {
          method: 'POST',
          body: JSON.stringify(model),
          headers: {
            'Content-Type': 'application/json',
          },
        })
          .then((r) => r.json())
          .then((r) => {
            const newItem = r as LinkListItemModel;
            patchState(store, addEntity(newItem));
          });
      },
      setSortOption: (sortOption: SortOptions) =>
        patchState(store, { sortOption }),
      load: async () => {
        patchState(store, { _apiState: 'fetching' });
        await fetch('http://localhost:1337/links')
          .then((r) => r.json())
          .then((items) => {
            const links = items as LinkListItemModel[]; // This is DANGEROUS. Hold my beer. I know better than you.
            patchState(store, setAllEntities(links), { _apiState: 'idle' });
          });
      },
    };
  }),
  withComputed((store) => {
    return {
      isLoading: computed(() => store._apiState() === 'fetching'),
      sortedLinks: computed(() => {
        const sortOption = store.sortOption();
        const links = store.entities() || [];
        return [...links].sort((a, b) => {
          const dateA = new Date(a.created).getTime();
          const dateB = new Date(b.created).getTime();
          if (sortOption === 'newestFirst') {
            return dateB - dateA;
          } else {
            return dateA - dateB;
          }
        });
      }),
    };
  }),
  withHooks({
    // things the devloper this added that will be run at specific times in the life of this thing.
    onInit(store) {
      store.load();
    },
  }),
);
