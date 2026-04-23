using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ContactManager.Core;

public class ContactService
{
    private InMemoryContactRepository repository; // kleine letter want het is een field, om alle variablen aan te passen met dezelfde naam klik op variable en F2

    public ContactService(InMemoryContactRepository usedRepo)
    {
        repository = usedRepo;
    }
    public void AddContactToRepo(string name, string email, string PhoneNumber)
    {
        var contact = new Contact(name, email, PhoneNumber);
        repository.Add(contact);
    }

    public string GetContactAsStrings(Contact contact) //maakt een mooie string van contact info
    {
        return $"Naam: {contact.Name}  Email: {contact.Email}  Telefoonnummer: {contact.PhoneNumber}";
    }

    public List<string> GetAllContactsAsStrings()   //maakt een lijst van alle contacts in stringformaat
    {
        List<string> AllContactString = [];
        foreach (var contact in repository.GetAll())
        {
            AllContactString.Add(GetContactAsStrings(contact));
        }
        return AllContactString;
    }

    public Contact SearchContactId(int UniekeId)
    {
        var contactlist = repository.GetAll();
        foreach (var contact in contactlist)
        {
            if (contact.Id == UniekeId)
            {
                return contact;
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

    public void UpdateContact(int UniekeId, string name, string email, string number) //update the details van een contact
    {
        var contact = SearchContactId(UniekeId);
        contact.Update(name, email, number);
    }

    public void RemoveContact(int UniekeId)
    {
        repository.RemoveContact(UniekeId);
    }

    public string SearchContactName(string name)
    {
        return GetContactAsStrings(repository.SearchContactName(name));
    }
}