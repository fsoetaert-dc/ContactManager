using System.Xml.Serialization;

namespace ContactManager.Core;

public class Menu(IConsole console, ContactService service) //class Menu gemaakt die parameters IConsole en ContactService gebruiken. Deze worden opgeslagen in private fields
{
    public int Run()
    {
        var running = true;
        while (running)
        {
            ShowMenu();
            running = HandleChoice(console.ReadLine());
        }
        return 0;
    }

    private void ShowMenu()
    {
        console.WriteLine("1. Contact Toevoegen");
        console.WriteLine("2. Toon Contactenlijst");
        console.WriteLine("3. Contact Aanpassen");
        console.WriteLine("4. Contact Verwijderen");
        console.WriteLine("5. Contact Zoeken");
        console.WriteLine("q. Exit");
        console.Write("Maak uw keuze:");
    }

    private void HandleContact()
    {
        console.WriteLine("Voer een naam in: ");
        var nameContact = console.ReadLine();
        console.WriteLine("Voer een emailadres in: ");
        var emailContact = console.ReadLine();
        console.WriteLine("Voer een telefoonnummer in: ");
        var numberContact = console.ReadLine();
        service.AddContactToRepo(nameContact, emailContact, numberContact);
        console.WriteLine($"Contact toegevoegd: {nameContact}");
    }

    private void ShowContactList()
    {
        foreach (var contact in service.GetAllContactsAsStrings())
        {
            console.WriteLine(contact); // staat nu mooi op 1 lijn
        }
    }

    private void UpdateContact()
    {
        console.WriteLine("Geef het Idnummer in");
        var IdStr = console.ReadLine();
        foreach (var letter in IdStr)
        {
            if (!char.IsDigit(letter))
            {
                console.WriteLine("Ingegeven waarde is geen nummer");
                return;
            }
        }
        var IdInt = int.Parse(IdStr);
        console.WriteLine("Pas de naam aan");
        var aanpassingNaam = Console.ReadLine();
        console.WriteLine("Pas de email aan");
        var aanpassingEmail = Console.ReadLine();
        console.WriteLine("Pas de telefoonnummer aan");
        var aanpassingNummer = Console.ReadLine();
        try
        {
            service.UpdateContact(IdInt, aanpassingNaam, aanpassingEmail, aanpassingNummer);
            console.WriteLine($"Account met Idnummer {IdInt} is aangepast");
        }
        catch (Exception ex)
        {
            console.WriteLine(ex.Message);
        }
    }

    public void RemoveContact()
    {
        console.WriteLine("Geef het Idnummer in");
        var Idstr = console.ReadLine();

        try
        {
            int Idint = int.Parse(Idstr);
            service.RemoveContact(Idint);
            console.WriteLine($"Account met Idnummer {Idint} is verwijderd");
        }
        catch (FormatException)
        { console.WriteLine("Ingegeven Idnummer is geen nummer"); }
        catch (Exception ex)
        { console.WriteLine(ex.Message); }
    }

    public void SearchContact()
    {
        console.WriteLine("Geef de naam in van het account");
        var contactName = console.ReadLine();
        var foundName = string.Empty;
        try
        {
            foundName = service.SearchContact(contactName);
            console.WriteLine(foundName);
        }
        catch (Exception ex)
        {
            console.WriteLine(ex.Message);
        }
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "q": return false;
            case "1": HandleContact(); break;
            case "2": ShowContactList(); break;
            case "3": UpdateContact(); break;
            case "4": RemoveContact(); break;
            case "5": SearchContact(); break;

            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }
}