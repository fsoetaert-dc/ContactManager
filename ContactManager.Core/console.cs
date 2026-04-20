namespace ContactManager.Core;

public interface IConsole
{
    public void WriteLine(string message);
    public void Write(string message);
    public string ReadLine();
}
public class SystemConsole : IConsole
{
    public void WriteLine(string message) => Console.WriteLine(message);
    public void Write(string message) => Console.Write(message);
    public string ReadLine() => Console.ReadLine()!;
}