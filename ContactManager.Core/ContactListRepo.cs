using System.ComponentModel;

namespace ContactManager.Core;

public class InMemoryContactRepository //class InMemoryContactRepository aangemaakt die een method Add heeft (heeft geen parameters nodig, maakt een nieuwe repo aan => var repo1 = new InMemoryContactRepository)
{
    public IReadOnlyList<Contact> GetAll() { return contactList; }

    private int uniqueId = 1; //base Id en telt 1 op bij elk nieuw contact in AddContact

    private List<Contact> contactList = [];
    public void Add(Contact contact)    //Add voegt een contact en een unieke Idnummer toe
    {
        contactList.Add(contact);
        contact.Id = uniqueId;
        uniqueId += 1;
    }

    public void RemoveContact(int Idnummer)
    {
        foreach (var contact in contactList)
        {
            if (contact.Id == Idnummer)
            {
                contactList.Remove(contact);
                return;
            }

        }
        throw new Exception("Contact niet in de lijst");
    }

    public Contact SearchContactName(string name)
    {
        foreach (var contact in contactList)
        {
            if (contact.Name == name)
            {
                return contact;
            }
        }
        throw new Exception("Naam niet in de accountlijst");
    }
}