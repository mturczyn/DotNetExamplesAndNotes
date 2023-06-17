using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamplesAndNotes.ConsoleApp.EitherType;

public class Either<T1, T2>
{
    private readonly T1 _value1;
    private readonly T2 _value2;
    private readonly bool _isValue1;

    public Either(T1 value1)
    {
        _value1 = value1;
        _isValue1 = true;
    }

    public Either(T2 value2)
    {
        _value2 = value2;
        _isValue1 = false;
    }

    public static implicit operator Either<T1, T2> (T1 value)
    {
        return new Either<T1, T2>(value);
    }


    public static implicit operator Either<T1, T2>(T2 value)
    {
        return new Either<T1, T2>(value);
    }

    public T Match<T>(Func<T1,T> f1, Func<T2, T> f2)
    {
        return _isValue1 ? f1(_value1) : f2(_value2);
    }
}
