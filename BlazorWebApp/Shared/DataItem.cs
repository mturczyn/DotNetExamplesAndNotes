public class DataItem
{
    public string Minute { get; private set; }

    public decimal Value { get; private set; }

    public DataItem(string minute, decimal value)
    {
        Minute = minute;
        Value = value;
    }
}
