using ContactManager.Core; //zeggen welke map/files je gebruikt als deze in andere mappen zitten

namespace ContactManager.CLI;

//code for the console

public class SystemConsole : IConsole
{
    public void WriteLine(string message) => Console.WriteLine(message);
    public void Write(string message) => Console.Write(message);
    public string ReadLine() => Console.ReadLine()!;
}