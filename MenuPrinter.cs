namespace LINQTutorial;

public class MenuPrinter
{
    public void PrintMenu(List<MenuItem> items) 
    {
        Console.Clear();
        Console.WriteLine("=== MENU ===\n");
        foreach (MenuItem item in items) 
        {
            Console.WriteLine($"{item.Key}. {item.Text}");
        }
    }
}
