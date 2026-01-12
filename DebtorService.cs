namespace LINQTutorial;

public class DebtorService
{
    private readonly DebtorRegistry _registry;

    public DebtorService(DebtorRegistry registry)
    {
        _registry = registry;
    }

    public void ViewDebtors()
    {
        foreach (var debtor in _registry.GetDebtors())
        {
            Console.WriteLine(debtor.ToString());
        }
        Console.ReadKey();
    }


    public void ViewSpecializedDebtors(IEnumerable<Debtor> result)
    {
        if (result == null || !result.Any())
        {
            Console.WriteLine("No debtors found matching the criteria.");
            return;
        }

        foreach (var debtor in result)
        {
            Console.WriteLine(debtor.ToString());
        }
    }

    public void ExecuteAndShow(Func<IEnumerable<Debtor>> queryLogic)
    {
       
        var result = queryLogic();

        ViewSpecializedDebtors(result);

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    public IEnumerable<Debtor> GetRhytaAndDayrepUsers()
    {
        List<Debtor> debtors = _registry.Debtors;
        IEnumerable<Debtor> query = from debtor in debtors
                                    where debtor.Email.EndsWith("rhyta.com") || debtor.Email.EndsWith("dayrep.com")
                                    orderby debtor.Email.Length
                                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsByAgeRange()
    {
        List<Debtor> debtors = _registry.Debtors;
        int minAge = 26; int maxAge = 36;
        var query = debtors.Where(d => (DateTime.Now.Year - d.BirthDay.Year) >= minAge &&
                                         (DateTime.Now.Year - d.BirthDay.Year) <= maxAge)
                           .OrderBy(d => d.BirthDay.Year)
                           .Select(d => d);
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsUnderLimit()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = from debtor in debtors
                    where debtor.Debt <= 5000
                    orderby debtor.Debt
                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> GetSpecificDebtorsByNameAndContact()
    {
        List<Debtor> debtors = _registry.Debtors;
        char anyDigit = '7';
        IEnumerable<Debtor> query = from debtor in debtors
                                    where debtor.FullName.Length > 18 && debtor.Phone.Count(d => d == anyDigit) >= 2
                                    orderby debtor.FullName, debtor.Phone
                                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsBornInWinter()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = debtors.Where(d => d.BirthDay.Month == 12 || d.BirthDay.Month == 1 || d.BirthDay.Month == 2)
                           .OrderBy(d => d.BirthDay.Month)
                           .Select(d => d);
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsAboveAverage()
    {
        List<Debtor> debtors = _registry.Debtors;
        double average = debtors.Average(d => d.Debt);
        IEnumerable<Debtor> query = from debtor in debtors
                                    where debtor.Debt > average
                                    orderby debtor.FullName ascending, debtor.Debt descending
                                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> FilterDebtorsByMissingDigitInPhone()
    {
        List<Debtor> debtors = _registry.Debtors;
        char anyDigit = '8'; 
        var query = debtors.Where(d => !(d.Phone.Contains(anyDigit)))
                           .Select(d => d);
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsWithTripleRepeatingLetters()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = from debtor in debtors
                    let fullnamePair = debtor.FullName.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    where fullnamePair.Length >= 2 &&
                          fullnamePair[0].GroupBy(s => char.ToLower(s)).Any(s => s.Count() >= 3) ||
                          fullnamePair[1].GroupBy(n => char.ToLower(n)).Any(n => n.Count() >= 3)
                    orderby debtor.FullName
                    select debtor;
        return query;
    }

    public int GetTopBirthYear()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = debtors.GroupBy(d => d.BirthDay.Year)
                           .MaxBy(y => y.Count())
                           ?.Key ?? 0;
        return query;
    }

    public IEnumerable<Debtor> GetTop5DebtorsByDebt()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = debtors.OrderByDescending(d => d.Debt)
                            .Take(5);
        return query;
    }

    public int GetTotalDebtAmount()
    {
        List<Debtor> debtors = _registry.Debtors;
        var query = (from debtor in debtors
                     select debtor.Debt).Sum();
        return query;
    }

    public IEnumerable<Debtor> GetWW2SurvivorDebtors()
    {
        List<Debtor> debtors = _registry.Debtors;
        IEnumerable<Debtor> query = from debtor in debtors
                                    where debtor.BirthDay.Year < 1945
                                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsWithUniquePhoneDigits()
    {
        List<Debtor> debtors = _registry.Debtors;
        IEnumerable<Debtor> query = from debtor in debtors
                                    let cleanPhone = debtor.Phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")
                                    where cleanPhone.Distinct().Count() == cleanPhone.Length
                                    select debtor;
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsWhoCanPayOffByBirthday()
    {
        List<Debtor> debtors = _registry.Debtors;
        DateTime today = DateTime.Now;
        var query = from d in debtors
                    let nextBirthday = new DateTime(today.Year, d.BirthDay.Month, d.BirthDay.Day)
                    let finalBirthday = nextBirthday < today ? nextBirthday.AddYears(1) : nextBirthday
                    let monthsToBirthday = ((finalBirthday.Year - today.Year) * 12) + finalBirthday.Month - today.Month
                    where (monthsToBirthday * 500) >= d.Debt
                    select d;
        return query;
    }

    public IEnumerable<Debtor> GetDebtorsWhoCanSpellSmile()
    {
        List<Debtor> debtors = _registry.Debtors;
        char[] searchChars = { 's', 'm', 'i', 'l', 'e' };
        var query = debtors.Where(d => searchChars.All(c => d.FullName.ToLower().Contains(c)))
                    .Select(d => d);
        return query;
    }
}
