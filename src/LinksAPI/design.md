# Our Links API

## Adding a Link

- Define the Resource
- Select the proper method (GET POST PUT DELETE)
- Define our "representation" - how we are going to pass data from the client to the server, and how the server is going to send us data.

```http
POST http://localhost:1337/links
Content-Type: application/json
Authorization: bearer 39378973973973

{
  "href": "https://allstate.com",
  "description": "Good insurance. Great Developers"
}
```


```http
201 Created
Content-Type: application/json
Location: /links/38983989839839839893

{
  "id": "38983989839839839893",
  "href": "https://typescriptlang.org",
  "description": "The TypeScript Website",
  "addedBy": "jeff@hypertheory.com",
  "created": "some datetime"
}
```

GET /links/38983989839839839893



Here is some sample code:

```typescript
const name = 'Jeff';
console.log(name.toUpper());
```

Http Status Codes:


200 - 299: This worked. 

201 - Created

300 - 399: Need more information or redirects.

400 - 499: The user agent (the client making the request) did something wrong.

401 - You need to be authenticated. We gotta know who you are.
403 - I Know who you are and you SPECIFICALLY can't do this.

404 - 

500 - 599: We screwed up. SHAME! 

