using System.Xml.Serialization;

namespace ContactManager.Core;

public class Menu(IConsole console, ContactService service) //class Menu gemaakt die parameters IConsole en ContactService gebruiken. Deze worden opgeslagen in private fields
{
    private IConsole Console = console;
    private ContactService Service = service;

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
        console.WriteLine("q. Exit");
        console.Write("Maak uw keuze:");
    }

    private void HandleContact()
    {
        console.WriteLine("Voer een naam in: ");
        var nameContact = console.ReadLine();
        service.AddContactToRepo(nameContact);
        console.WriteLine($"Contact toegevoegd: {nameContact}");

    }

    private void ShowContactList()
    {
        foreach (var contact in Service.GetContactsAsStrings())
        {
            console.WriteLine(contact);
        }
    }

    private void UpdateContact()
    {
        console.WriteLine("Geef Idnummer in");
        var Idstr = console.ReadLine();
        foreach (var letter in Idstr)
        {
            if (!char.IsDigit(letter))
            {
                console.WriteLine("Geen nummer");
                return;
            }
        }
        var Idnummer = int.Parse(Idstr);
        console.WriteLine("Pas de naam aan");
        var aanpassingNaam = Console.ReadLine();
        console.WriteLine("Pas de email aan");
        var aanpassingEmail = Console.ReadLine();
        console.WriteLine("Pas de telefoonnummer aan");
        var aanpassingNummer = Console.ReadLine();
        try
        {
            Service.UpdateContact(Idnummer, aanpassingNaam, aanpassingEmail, aanpassingNummer);
        }
        catch (Exception ex)
        {
            console.WriteLine(ex.Message);
        }
        Service.UpdateContact(Idnummer, aanpassingNaam, aanpassingEmail, aanpassingNummer);
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "q": return false;
            case "1": HandleContact(); break;
            case "2": ShowContactList(); break;
            case "3":; break;

            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }
}