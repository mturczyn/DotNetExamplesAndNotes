using Microsoft.Extensions.Options;

namespace DotNetExamplesAndNotes.ConsoleAppDI;

public class NumberConfig
{
    public int Default { get; set; }
}

public interface INumberRepository
{
    int GetNumber();
}

public class NumberRepository : INumberRepository
{
    private readonly NumberConfig _config;

    public NumberRepository(IOptions<NumberConfig> options)
    {
        _config = options.Value;
    }

    public int GetNumber()
    {
        return _config.Default;
    }
}
