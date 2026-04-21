using System.Runtime.CompilerServices;

namespace ContactManager.Core;

public class ContactService
{

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
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

}