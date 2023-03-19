namespace DotNetExamplesAndNotes.ConsoleApp.RecordPrintMembers;

public class PrintMembersTestArea
{
    static void Run()
    {
        PrintResult(() => new Person("Michal", "Turczyn"));
        PrintResult(() => new PersonWithNumbers("Michal", "Turczyn", new[] { "0050062345", "+48504546465" }));
        PrintResult(() => new PersonWithMemberPrint("Michal", "Turczyn", new[] { "0050062345", "+48504546465" }));
    }

    static void PrintResult<T>(Func<T> factory)
    {
        Console.WriteLine(factory());
    }
}
