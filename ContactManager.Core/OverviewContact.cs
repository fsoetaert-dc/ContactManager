using System.ComponentModel;

namespace ContactManager.Core;

public class InMemoryContactRepository //class InMemoryContactRepository aangemaakt die een method Add heeft (heeft geen parameters nodig, maakt een nieuwe repo aan => var repo1 = new InMemoryContactRepository)
{
    public IReadOnlyList<Contact> GetAll() { return ContactList; }
    private int UniqueId = 1; //base Id en telt 1 op bij elk nieuw contact in AddContact

    private List<Contact> ContactList = [];
    public void Add(Contact contact)    //Add voegt een contact en een unieke Idnummer toe
    {
        ContactList.Add(contact);
        contact.Id = UniqueId;
        UniqueId += 1;
    }

    public void RemoveContact(int Idnummer)
    {
        foreach (var contact in ContactList)
        {
            if (contact.Id == Idnummer)
            {
                ContactList.Remove(contact);
            }
        }
    }

    public string SearchContact(string name)
    {
        foreach (var contact in ContactList)
        {
            if (contact.Name == name)
            {
                return contact.Name + " " + contact.Email + " " + contact.PhoneNumber;
            }
        }
        throw new Exception("Naam niet in de accountlijst");
    }
}