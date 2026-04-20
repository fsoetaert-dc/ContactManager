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

public class FakeConsole : IConsole
{
    public List<string> Output = new();
    public Queue<string> Input = new();

    public void WriteLine(string message) => Output.Add(message);
    public void Write(string message) => Output.Add(message);
    public string ReadLine() => Input.Dequeue();
}