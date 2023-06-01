using DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        //await AsyncOperationsWithIterators.AsyncWithIteratorsExample();
        //TestArea.VisitorPaternTestArea();

        //Calculator.Start();
        //ProgrammingTaskFactFinder.Test();

        SourceLink();
    }

    private static void SourceLink()
    {
        var t = new Test() { Id = 1 };

        using var fileWriter = File.OpenWrite(@"C:\users\mt\desktop\jsontest.txt");
        using var streamReader = new StreamWriter(fileWriter);

        JsonSerializer.Create().Serialize(streamReader, t);
    }

    private class Test
    {
        public int Id { get; set; }
    }
}
