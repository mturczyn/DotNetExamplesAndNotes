using System.ComponentModel;

namespace DotNetExamplesAndNotes.ConsoleApp;

public static class Calculator
{
    public static void Start()
    {
        var key = ConsoleKey.Enter;

        while (key == ConsoleKey.Enter)
        {
            var operation = GetOperation();
            var number1 = GetNumber();
            var number2 = GetNumber(operation == Operation.Divide);

            var result = operation switch
            {
                Operation.Add => number1 + number2,
                Operation.Subtract => number1 - number2,
                Operation.Multiply => number1 * number2,
                Operation.Divide => number1 / number2,
                _ => throw new InvalidEnumArgumentException(),
            };

            Console.WriteLine($"Calculated result is {result}");

            Console.WriteLine("Press Enter to continue, or other key to exit");
            key = Console.ReadKey().Key;
        }

    }

    private static Operation GetOperation()
    {
        Console.WriteLine("Please enter operation: +, -, *, /");

        Operation? operation = null;

        while (!operation.HasValue)
        {
            var operationToParse = Console.ReadLine();

            operation = operationToParse switch
            {
                "+" => Operation.Add,
                "*" => Operation.Multiply,
                "-" => Operation.Subtract,
                "/" => Operation.Divide,
                _ => null
            };

            if (!operation.HasValue)
            {
                Console.WriteLine("Wrong operation, please provide correct one");
            }
        }

        return operation.Value;
    }

    private static double GetNumber(bool isDivisor = false)
    {
        Console.WriteLine("Please, provide a number");
        while (true)
        {
            var numberToParse = Console.ReadLine();

            if (!double.TryParse(numberToParse, out var number))
            {
                Console.WriteLine("Wrong number, please provide correct one");
                continue;
            }

            if (isDivisor && number == 0)
            {
                Console.WriteLine("Trying to divide by zero. Not allowed, enter correct number");
                continue;
            }

            return number;
        }
    }
}

public enum Operation
{
    Add, Multiply, Subtract, Divide,
}
