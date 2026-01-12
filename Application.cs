namespace LINQTutorial;

public class Application
{
    private readonly MenuPrinter _printer;
    private readonly MenuHandler _handler;
    private readonly DebtorService _debtorService;
    public Application(DebtorService debtorService, MenuHandler handler, MenuPrinter printer)
    {
        _debtorService = debtorService;
        _handler = handler;
        _printer = printer;
    }

    public void Run()
    {
        List<MenuItem> mainMenu = CreateMenu();
        _handler.NavigateMenu(mainMenu);
    }
    private List<MenuItem> CreateMenu()
    {
        var subMenu = new List<MenuItem>
    {
        new MenuItem(1, "Extract debtors (rhyta.com)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetRhytaAndDayrepUsers())),

        new MenuItem(2, "List debtors aged between 26 and 36",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsByAgeRange())),

        new MenuItem(3, "Debt <= 5000",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsUnderLimit())),

        new MenuItem(4, "Full name > 18 chars & '7' in phone (>=2)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetSpecificDebtorsByNameAndContact())),

        new MenuItem(5, "Born during winter months",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsBornInWinter())),

        new MenuItem(6, "Debt > average (Sorted Z-A & Debt Desc)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsAboveAverage())),

        new MenuItem(7, "Phone without specific digit (8)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.FilterDebtorsByMissingDigitInPhone())),

        new MenuItem(8, "Names with 3 repeating identical letters",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsWithTripleRepeatingLetters())),

        new MenuItem(9, "Year with the highest births",
            () => {
                int year = _debtorService.GetTopBirthYear();
                Console.WriteLine($"\n>>> Result: The year with highest births is {year}");
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
            }),

        new MenuItem(10, "Top 5 debtors by debt",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetTop5DebtorsByDebt())),

        new MenuItem(11, "Total owed amount",
            () => {
                int total = _debtorService.GetTotalDebtAmount();
                Console.WriteLine($"\n>>> Result: Total owed amount is: {total} AZN");
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }), 

        new MenuItem(12, "Born before 1945 (WWII survivors)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetWW2SurvivorDebtors())),

        new MenuItem(13, "Unique phone digits",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetWW2SurvivorDebtors())),

        new MenuItem(14, "Pay off by next birthday (500 AZN/mo)",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsWhoCanPayOffByBirthday())),

        new MenuItem(15, "Full name contains all letters of 'smile'",
            () => _debtorService.ExecuteAndShow(() => _debtorService.GetDebtorsWhoCanSpellSmile())),

        new MenuItem(16, "Back", null)
    };

        var mainMenu = new List<MenuItem>
    {
        new MenuItem(1, "View All Debtors", () => _debtorService.ViewDebtors()),
        new MenuItem(2, "Add New Debtor", () => Console.WriteLine("Coming soon...")),
        new MenuItem(3, "Advanced Filtering & Analysis", null, subMenu),
        new MenuItem(4, "Exit", () => Environment.Exit(0))
    };

        return mainMenu;
    }

}
