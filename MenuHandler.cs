using System.Reflection;

namespace LINQTutorial;

public class MenuHandler
{
    private readonly PromptService _promptService;
    private readonly MenuPrinter _menuPrinter;
    public MenuHandler(PromptService promptService, MenuPrinter menuPrinter)
    {
        _promptService = promptService;
        _menuPrinter = menuPrinter;
    }

    public void NavigateMenu(List<MenuItem> currentMenu)
    {
        while (true)
        {
            Console.Clear();
            _menuPrinter.PrintMenu(currentMenu);

            int choice = _promptService.GetValidatedMenuChoice(1, currentMenu.Count);

         
            var selected = currentMenu[choice - 1];

          
            if (selected.Text == "Back")
                return;


            if (selected.Text == "Exit")
                Environment.Exit(0);

    
            if (selected.HasSubItem)
            {
                NavigateMenu(selected.SubItems);
                continue;
            }

            if (selected.Action != null)
            {
                Console.Clear();
                selected.Action.Invoke();

                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
            }
        }
    }
}


