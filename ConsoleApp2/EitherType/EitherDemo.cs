using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamplesAndNotes.ConsoleApp.EitherType;
public static class EitherDemo
{
    public static void Demonstrate()
    {
        Either<string, int> eitherOne = 42;
        eitherOne = "bla bla";
    }
}
