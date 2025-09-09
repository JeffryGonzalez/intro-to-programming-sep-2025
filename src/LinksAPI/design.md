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
200 Ok
Content-Type: application/json

{
  "id": "38983989839839839893",
  "href": "https://typescriptlang.org",
  "description": "The TypeScript Website",
  "addedBy": "jeff@hypertheory.com",
  "created": "some datetime"
}
```


Here is some sample code:

```typescript
const name = 'Jeff';
console.log(name.toUpper());
```