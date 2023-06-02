namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.Luxoft;

public class StackMaxCountExceededException : Exception
{
    public StackMaxCountExceededException() : base("Trying to add item to stack when it's full") { }
}
