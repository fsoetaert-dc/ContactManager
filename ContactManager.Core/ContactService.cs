using System.Runtime.CompilerServices;

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

    public List<string> GetContactsAsStrings()
    {
        List<string> ContactToString = [];
        foreach (var contact in Repository.GetAll())
        {
            ContactToString.Add(contact.Name.ToString());
            ContactToString.Add(contact.Email.ToString());
            ContactToString.Add(contact.PhoneNumber.ToString());
        }
        return ContactToString;
    }

}