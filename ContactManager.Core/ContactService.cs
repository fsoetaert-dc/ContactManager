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
        var name = contact.Name.ToString();
        var email = contact.Email.ToString();
        var nummer = contact.PhoneNumber.ToString();
        return $"Naam: {name}  Email: {email}  Telefoonnummer: {nummer}";
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

    public void UpdateContact(int UniekeId, string name, string email, string number) //update the details van een contact
    {
        var contactlist = repository.GetAll();
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
        repository.RemoveContact(UniekeId);
    }

    public string SearchContact(string name)
    {
        return GetContactAsStrings(repository.SearchContact(name));
    }
}