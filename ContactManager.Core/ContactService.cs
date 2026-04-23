using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    public string GetContactAsStrings(Contact contact)
    {
        // nog niet zeker alle contacts of enkel 1 weergeven, do ik dit niet ook in SearchContact?
        var name = contact.Name.ToString();
        var email = contact.Email.ToString();
        var nummer = contact.PhoneNumber.ToString();
        return $"Naam: {name}  Email: {email}  Telefoonnummer: {nummer}";
    }

    public List<string> GetAllContactsAsStrings()
    {
        List<string> AllContactString = [];
        foreach (var contact in Repository.GetAll())
        {
            AllContactString.Add(GetContactAsStrings(contact));
        }
        return AllContactString;
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

    public string SearchContact(string name)
    {

        foreach (var contact in Repository.GetAll())
        {
            if (contact.Name == name)
            {
                var contactFound = Repository.SearchContact(name);
                var foundName = contactFound.Name.ToString();
                var email = contactFound.Email.ToString();
                var nummer = contactFound.PhoneNumber.ToString();
                return $"Naam: {foundName}  Email: {email}  Telefoonnummer: {nummer}";
            }
        }
        throw new Exception("Contact niet in de lijst");
    }

}