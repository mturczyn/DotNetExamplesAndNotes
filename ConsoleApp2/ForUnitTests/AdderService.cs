using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamplesAndNotes.ConsoleApp.ForUnitTests;

public static class AdderService
{
    public static int AddWithTweak(int a, int b)
    {
        if (a < 0)
        {
            return b;
        }

        if (b < 0)
        {
            return b - a;
        }

        return a + b;
    }
}
