# Our Links API

## Adding a Link

- Define the Resource
- Select the proper method (GET POST PUT DELETE)
- Define our "representation" - how we are going to pass data from the client to the server, and how the server is going to send us data.

```http
POST http://localhost:1337/links
Content-Type: application/json

{
  
}
```

Here is some sample code:

```typescript
const name = 'Jeff';
console.log(name.toUpper());
```