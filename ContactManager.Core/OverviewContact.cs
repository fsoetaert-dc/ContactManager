namespace ContactManager.Core;

public class InMemoryContactRepository
{
    public IReadOnlyList<Contact> GetAll() { return ContactList; }
    private int UniqueId = 1;

    private List<Contact> ContactList = [];
    public void Add(Contact contact)
    {
        ContactList.Add(contact);
        contact.Id = UniqueId;
        UniqueId += 1;
    }
}