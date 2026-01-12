namespace LINQTutorial;
public class DebtorAlreadyExitException : Exception
{
    public DebtorAlreadyExitException(string message) : base(message) { }
}

