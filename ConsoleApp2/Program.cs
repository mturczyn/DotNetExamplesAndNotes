using System.Runtime.CompilerServices;
using DotNetExamplesAndNotes.ConsoleApp.UnmanagedCodeExamples;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        await InterceptKeys.Run();
        //RuntimeHelpers.IsReferenceOrContainsReferences<string>();

        //await AsyncOperationsWithIterators.AsyncWithIteratorsExample();
        //TestArea.VisitorPaternTestArea();

        //Calculator.Start();
        //ProgrammingTaskFactFinder.Test();

        //SourceLink();

        //ProgrammingTaskRiteNRG.TestMethod();

        //EitherDemo.Demonstrate();

        //foreach (var item in GetInts())
        //{
        //    Console.WriteLine(item);
        //}

    }

    private static IEnumerable<int> GetInts()
    {
        yield return 1;
        yield return 2;
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
