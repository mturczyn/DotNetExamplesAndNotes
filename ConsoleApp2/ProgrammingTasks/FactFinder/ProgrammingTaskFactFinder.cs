using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.FactFinder;
/*
 * Implement the following method to calculate the number of days between two dates A and B 
 * within one and the same year.

public int Diff(int mA, int dA, int mB, int dB)
{
}
*/

public static class ProgrammingTaskFactFinder
{
    public static void Test()
    {
        TestCase(1, 1, 12, 31, 2023, 364);

        TestCase(12, 31, 1, 1, 2023, 364);

        TestCase(12, 31, 1, 1, 2024, 365);

        //TestCase(2, 29, 1, 1, 2023, 365);

        //TestCase(2, 29, 1, 1, 2023, 365);

        TestCase(2, 4, 1, 1, 2023, 34);

        TestCase(2, 4, 1, 1, 2024, 34);

        TestCase(3, 4, 4, 1, 2024, 28);

        for (var month = 1; month <= 12; month++)
        {
            for (var day = 1; day <= 28; day++)
            {
                TestCase(month, day, month, day, 2024, 0);
            }
        }

        TestCase(3, 1, 3, 30, 2024, 29);
        TestCase(2, 1, 2, 29, 2024, 28);
        //TestCase(2, 1, 2, 29, 2023, 28);

    }

    public static void TestCase(int mA, int dA, int mB, int dB, int year, int expected)
    {
        Debug.Assert(Diff(mA, dA, mB, dB, year) == expected);
    }

    public static int DiffOld(int mA, int dA, int mB, int dB, int year)
    {
        var dtA = new DateTime(year, mA, dA);
        var dtB = new DateTime(year, mB, dB);

        return Math.Abs((dtA - dtB).Days);
    }

    private static Dictionary<int, int> DaysInMonth = new()
    {
        {1, 31 },
        {2, 28 },
        {3, 31 },
        {4, 30 },
        {5, 31 },
        {6, 30 },
        {7, 31 },
        {8, 31 },
        {9, 30 },
        {10, 31 },
        {11, 30 },
        {12, 31 },
    };

    public static int Diff(int mA, int dA, int mB, int dB, int year)
    {
        // validated input
        if (mA == mB) return Math.Abs(dA - dB);

        (var firstMonth, var secondMonth) = mA < mB ? (mA, mB) : (mB, mA);
        (var firstDay, var secondDay) = firstMonth == mA ? (dA, dB) : (dB, dA);

        var days = DaysInMonth[firstMonth] - firstDay;
        days += secondDay;

        // for leap year, add one if it contains 29 of Feb
        var leapYear = year % 4 == 0 && year % 100 != 0 || year % 400 == 0;

        for (var i = firstMonth + 1; i < secondMonth; i++)
        {
            days += DaysInMonth[i];
            if (leapYear && i == 2) days++;
        }

        return days;
    }

}
