# Code Review
- remove unused namespaces

## Core
- `ContactService`
  - `contact1` leest ni echt lekker, `contact` beter
  - `private InMemoryContactRepository Repository;` 
    => private field = camelCase => `repository`

- `InMemoryContactRepository`
  - `ContactList` => `contactList`: see above
  - rename file

  ## Tests
  - rename UnitTest1 class
  - one class per file
  
