namespace LINQTutorial;
public class Validation
{
    public string CheckValidation(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException("This field is required. Please provide the necessary information.");
        return input; 
    }
    public string ValidateMenuSelection(string input, int minRange, int maxRange ) 
    {
        int choice = int.Parse(input!);
        if (!(choice >= minRange && choice <= maxRange)) throw new ArgumentOutOfRangeException($"Invalid selection.The option you entered is out of range. Please ensure you make a valid selection from the menu within the range of {minRange} to {maxRange}.");
        return input!;
    }
    
}