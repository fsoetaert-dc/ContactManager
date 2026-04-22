using System.Runtime.CompilerServices;

namespace ContactManager.Core;

public class ContactService
{
    public Contact FoundContact;
    private InMemoryContactRepository Repository;

    public ContactService(InMemoryContactRepository usedRepo)
    {
        Repository = usedRepo;
    }
    public void AddContactToRepo(string name)
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

    public void UpdateContact(int UniekeId, string name, string email, string number)
    {
        var contactlist = Repository.GetAll();
        foreach (var contact in contactlist)
        {
            if (contact.Id == UniekeId)
            {
                contact.Update(name, email, number);
                return;
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

    public void RemoveContact(int UniekeId)
    {
        var contactlist = Repository.GetAll();
        foreach (var contact in contactlist)
        {
            if (contact.Id == UniekeId)
            {
                Repository.RemoveContact(UniekeId);
                return;
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

    public void SearchContact(string name)
    {
        var contactlist = Repository.GetAll();
        foreach (var contact in contactlist)
        {
            if (contact.Name == name)
            {
                Repository.SearchContact(name);
                var FoundContact = Repository.FoundContact;
                return;
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

}