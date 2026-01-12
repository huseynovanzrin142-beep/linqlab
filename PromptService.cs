namespace LINQTutorial
{
    public interface IPromptService
    {
        int GetValidatedMenuChoice(int min, int max);
    }

    public class PromptService : IPromptService
    {
        private readonly InputService? _inputService;
        private readonly Validation? _validation;
        public PromptService(InputService inputService, Validation validation)
        {
            _inputService = inputService;
            _validation = validation;
        }

        public int GetValidatedMenuChoice(int min, int max) 
        {
            while (true) 
            {
                string? input = _inputService.GetDataFromUser();
                string? finalSelection = string.Empty;
                try
                {   
                    string? validatedEmpty = _validation.CheckValidation(input);
                    finalSelection = _validation.ValidateMenuSelection(validatedEmpty,min,max);     
                }
                catch (ArgumentOutOfRangeException e) 
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[XETA MESAJI :] {e.Message}");
                }
                return int.Parse(finalSelection);
            }
        }
    }
}
