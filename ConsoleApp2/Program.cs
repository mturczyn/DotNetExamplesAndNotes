using DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.RiteNRG;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        //await AsyncOperationsWithIterators.AsyncWithIteratorsExample();
        //TestArea.VisitorPaternTestArea();

        //Calculator.Start();
        //ProgrammingTaskFactFinder.Test();

        //SourceLink();

        ProgrammingTaskRiteNRG.TestMethod();
    }

    private static void InKeyword(in int number)
    {
        // Below line produces error
        //number = 12;
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
