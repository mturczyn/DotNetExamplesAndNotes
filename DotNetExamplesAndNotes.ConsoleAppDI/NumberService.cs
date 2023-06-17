namespace DotNetExamplesAndNotes.ConsoleAppDI;

public interface INumberService
{
    int GetNumber();
}

public class NumberService : INumberService
{
    public int GetNumber()
    {
        return 42;
    }
}
