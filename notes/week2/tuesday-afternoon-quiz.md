# Your Quiz

## What is Angular? What is it *for*?

I could write "raw" JavaScript and HTML and CSS to create an application.

A framework which we borrow from smarter people than us (hopefully) that have figured out some good ways to build applications that run in a web browser.

Not for "web sites" - you don't need all this.

An app allows "direct manipulation of the state by the user". Apps are stateful.

## In Angular, What is a Component?

A thing the Angular team gave a name to that is:

- An abstraction (a thingy) that is:
1. Responsible for an area of user interface in an application.

Components do two big things:

1. They project the application state to the user so the user can make decisions on that state.
2. Provide "affordances" through which the user can express their intent (manipulate the state).




## What is the "root" component - that holds all of our other components?

An Angular application has a component that is the "ancestor" of all your application's components. 

It is usually called `App` - with a selector like `app-root`

## What is "routing" in Angular?

- A way to have variable "modes" in your application.
- we are doing "Single Page Applications" - but that doesn't mean everything has to be on a single page. Duh.
- We can navigate between those using familiar browser conventions - like links, back button, forward buttons, all that jazz.
- Angular "hijacks" that from what the browser usually does and uses our route configuration to put our application in the correct "mode".
- routes are the primary source of "application state" - more on this tomorrow.


## If a parent component contains a child component, what must the child component have to allow the parent to pass a child some data?
- Angular intentionally makes this limited.
    - a parent can pass data to it's immediate children *only*. It can't pass data to it's grandchildren, for example.
    - Siblings can't talk to each other. 
- An input. 
## If a child component wants to inform the parent of some "event", what must the child component have? 
- the component has to declare an `output` - saying "I can tell you this thing"

- How does the parent component "handle" that event?

Use the `(output)="codeToRun()` thingy. 



## What is a service?

- Some code that is responsible for some state (data) and all the process associated with that state.
- it is a way to "reify" a concept in programming.
- We went from having a component that had some data like our balance, the amount we want to withdraw, etc.
    - and we decided that should be a "first class" concept in our application.
    - We created a "BankAccountStore" 

- Services have:
    - A scope and a lifetime.
    - Scope: Where can this be used?
    - Lifetime: When is this service created and when is it destroyed (taken out of memory).

- e.g. In our Links Api, we have a service called `IDocumentSession` - this is how we are accessing out database.
    - It's scope is anywhere in our application. You can inject it in anywhere.
    - It's lifetime is the HTTP request. This is called a "Scoped" Service in .NET.


## What does it mean to "provide" a service?

- The scope and lifetime of a service is dependent *solely* on *where* it is provided.

- When you provide a service in Angular on the components `providers: []`:
    - That service is created when the component is created.
    - It is destroyed when the component is destroyed (the user leaves the component)
    - It's also "reused" for any child components of that component.
- When you provide a service in the route's `providers: []` -
    - It will be created when that route is entered.
    - It will NEVER be destroyed (until you close the browser, refresh the page, etc.)

## What is the `inject()` function in Angular?

How we get a reference to the provided service that we can use.


## What is a `signal`?

An object that we use to hold some state and make sure the UI stays updated with that state whenever we change it.

## What is a `computed` signal?

A signal that is based on the values of other signals, and will update and "track" those signals to make sure it always has the right value.