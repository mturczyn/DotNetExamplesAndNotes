using System.Text;

public static class StringBuilderHelpers
{
    public static StringBuilder AppendPropertyWithValue<T>(StringBuilder stringBuilder, string propName, T value)
    {
        return stringBuilder.Append($"{propName} = {value}, ");
    }

    public static StringBuilder AppendPropertyWithValuesArray<T>(StringBuilder stringBuilder, string propName, T[] values)
    {
        return AppendPropertyWithValue(stringBuilder, propName, string.Join(',', values));
    }
}
