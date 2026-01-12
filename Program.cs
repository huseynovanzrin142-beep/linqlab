namespace LINQTutorial;
internal class Program
{
    static void Main(string[] args)
    {

        var registry = new DebtorRegistry();
        var service = new DebtorService(registry);
        var printer = new MenuPrinter();
        var handler = new MenuHandler(new PromptService(new InputService(), new Validation()), printer);

        var app = new Application(service, handler, printer);
        app.Run();


    }
}


