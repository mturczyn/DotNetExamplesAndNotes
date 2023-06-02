namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.Luxoft;

public interface IStack<T>
{
    void Push(T item);

    T Pop();

    public int Length { get; }
}
