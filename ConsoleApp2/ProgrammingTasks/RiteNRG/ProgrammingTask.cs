namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.RiteNRG;

public class ProgrammingTaskRiteNRG
{
    delegate int MyDelegate(int a, int b);

    public static void TestMethod()
    {
        MyDelegate md = Add;
        md = Subtract;
        md = Divide;

        Console.WriteLine($"Final result is {md(123, 123)}");
    }

    public static int Add(int a, int b)
    {
        Console.WriteLine("Adding");
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        Console.WriteLine("Subtracting");
        return a - b;
    }

    public static int Divide(int a, int b)
    {
        Console.WriteLine("Dividing");
        return a / b;
    }
}
