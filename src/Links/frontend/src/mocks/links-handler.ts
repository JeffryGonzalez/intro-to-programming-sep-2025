import { http, HttpResponse, delay } from 'msw';

const FAKE_LINKS = [
  {
    id: '1',
    title: 'TypeScript Playground',
    description: 'Learn you some typescript real good',
    href: 'https://typescriptlang.org/playground',
    addedBy: 'joe@aol.com',
    created: '2025-09-17T15:36:33.243Z',
  },
  {
    id: '2',
    title: 'Hypertheory Training',
    description: 'Best dang software training in the WORLD',
    href: 'https://www.hypertheory.com',
    addedBy: 'jeff@hypertheory.com',
    created: '2025-09-14T15:36:33.243Z',
  },
];

export const LinksApiTestDoubles = [
  http.get('http://localhost:1337/links', async () => {
    await delay(3000); // 100-200ms (simulate a "normal" network latency)
    // return HttpResponse.json([]);
    return HttpResponse.json(FAKE_LINKS);
  }),
];
