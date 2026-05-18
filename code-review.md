# Code Review
- remove unused namespaces

## Core
  - RemoveContact, SearchContact: doorzoeken van de contactlijst => naar Repository
    ```csharp
    var contactlist = Repository.GetAll();
        foreach (var contact in contactlist)
        ...
    ```
    maak bvb `InMemoryContactRepository.GetById(int id)` en `InMemoryContactRepository.GetByName(string name)`
  - never throw `Exception`, beter zo specifiek mogelijk, hier bvb `ArgumentException` of een eigen exception
- `InMemoryContactRepository`
  - `SearchContact` string formatting => `ContactService`
  ## Tests
  - rename UnitTest1 class
  - one class per file
  
