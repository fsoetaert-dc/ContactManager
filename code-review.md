# Code Review
- remove unused namespaces

## Core
- `Contact`:
  - String properties : voeg `= "";` toe als initalizatie, dit verwijdert *warning* op ctor.  
    Soms moet je de C# compiler wat helpen. De ene compiler is al wat slimmer dan de andere.
- `ContactService`
  - `contact1` leest ni echt lekker, `contact` beter
  - `private InMemoryContactRepository Repository;` 
    => private field = camelCase => `repository`
  - RemoveContact, SearchContact: doorzoeken van de contactlijst => naar Repository
    ```csharp
    var contactlist = Repository.GetAll();
        foreach (var contact in contactlist)
        ...
    ```
    maak bvb `InMemoryContactRepository.GetById(int id)` en `InMemoryContactRepository.GetByName(string name)`
  - never throw `Exception`, beter zo specifiek mogelijk, hier bvb `ArgumentException` of een eigen exception
- `InMemoryContactRepository`
  - `ContactList` => `contactList`: see above, same for `UniqueId`
  - rename file
  - `SearchContact` string formatting => `ContactService`
- `Menu`
  - unused fields, primary constructor is genoeg, verwijder deze:
    ```csharp
    private IConsole Console = console;
    private ContactService Service = service;
    ```
    Uw console => Console probleem zal opgelost zijn ;-).
  - `Idstr` => `idStr`
  - `Idint` => `idInt`

  ## Tests
  - rename UnitTest1 class
  - one class per file
  
