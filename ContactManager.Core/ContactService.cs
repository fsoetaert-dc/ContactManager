namespace ContactManager.Core;

public class ContactService
{

    private InMemoryContactRepository Repository;

    public ContactService(InMemoryContactRepository usedRepo)
    {
        Repository = usedRepo;
    }
    public void AddContact(string name)
    {
        var contact1 = new Contact(name);
        Repository.Add(contact1);
    }

}