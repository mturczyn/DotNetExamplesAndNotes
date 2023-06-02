namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.Luxoft;

public class MyStack<T> : IStack<T>
{
    private T[] _values;
    private const int MaxCount = 10;

    public MyStack()
    {
        _values = new T[0];
    }

    public MyStack(T[] values)
    {
        if (values.Length > MaxCount)
        {
            throw new StackMaxCountExceededException();
        }
        _values = values;
    }

    public int Length => _values.Length;

    public T Pop()
    {
        if (_values.Length == 0)
        {
            throw new StackEmptyException();
        }

        var toPop = _values[_values.Length - 1];
        Array.Resize(ref _values, _values.Length - 1);
        return toPop;
    }

    public void Push(T item)
    {
        if (_values.Length >= MaxCount)
        {
            throw new StackMaxCountExceededException();
        }

        var newSlotIndex = _values.Length;
        Array.Resize(ref _values, _values.Length + 1);
        _values[newSlotIndex] = item;
    }
}
