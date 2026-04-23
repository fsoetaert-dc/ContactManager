using System.ComponentModel;
using ContactManager.Core;

namespace ContactManager.Tests;

public class UnitTest1
{
    [Fact]
    public void CheckAdd()
    {
        var contact1 = new Contact("Bob");
        var repo = new InMemoryContactRepository();
        repo.Add(contact1);
        Assert.Equal(contact1, repo.GetAll()[0]);
    }

    [Fact]
    public void CheckAddId()
    {
        var contact1 = new Contact("Bob");
        var contact2 = new Contact("Alva");
        var repo = new InMemoryContactRepository();
        repo.Add(contact1);
        repo.Add(contact2);
        Assert.Equal(1, contact1.Id);
        Assert.Equal(2, contact2.Id);
    }
}

public class TestStep5
{
    [Fact]
    public void CheckAddContact()
    {
        var ContactService = new ContactService("repository");
        ContactService.AddContact


    }
}

public class FakeConsole : IConsole
{
    public List<string> Output = new();
    public Queue<string> Input = new();

    public void WriteLine(string message) => Output.Add(message);
    public void Write(string message) => Output.Add(message);
    public string ReadLine() => Input.Dequeue();
}


public class MenuTests
{
    private ContactService service = new(new InMemoryContactRepository());
    private FakeConsole console = new();

    private Menu menu;

    public MenuTests()
    {
        menu = new Menu(console, service);
    }

    [Fact]
    public void Menu_Q_Exits()
    {
        console.Input.Enqueue("q");
        Assert.Equal(0, menu.Run());
        Assert.Contains("q. Exit", console.Output);
    }
}

public class AddContactMenuTests
{
    private readonly InMemoryContactRepository repository = new();
    private readonly ContactService service;
    private readonly FakeConsole console = new();
    private readonly Menu menu;

    public AddContactMenuTests()
    {
        service = new ContactService(repository);
        menu = new Menu(console, service);
    }

    [Fact]
    public void Menu_AddContact_Flow()
    {
        console.Input.Enqueue("1");     // pick option
        console.Input.Enqueue("Elvis"); // input name
        console.Input.Enqueue("q");     // exit the loop.
        menu.Run();
        List<string> expected =
            // Initieel menu
            [ "1. Contact Toevoegen"
            , "q. Exit"
            , "Maak uw keuze:"
            // Na keuze '1'
            , "Voer een naam in: "  
            // Na toevoegen          
            , "Contact toegevoegd: Elvis"     
            // Turtles all the way down
            , "1. Contact Toevoegen"
            , "q. Exit"
            , "Maak uw keuze:"
            ];
        Assert.Equal(expected, console.Output);
        var contact = repository.GetAll()[0];
        Assert.Equal(1, contact.Id);
        Assert.Contains("Elvis", contact.Name);
    }
}