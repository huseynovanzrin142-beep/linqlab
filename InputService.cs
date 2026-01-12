using Microsoft.VisualBasic;

namespace LINQTutorial;

public class InputService
{
    public string GetDataFromUser()
    {
        string? input = string.Empty;
        Console.WriteLine("Please enter your choice : ");
        input = Console.ReadLine() ?? string.Empty;
        return input;
    }

}
