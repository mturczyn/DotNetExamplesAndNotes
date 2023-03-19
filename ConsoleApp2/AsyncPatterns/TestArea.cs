using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamplesAndNotes.ConsoleApp.AsyncPatterns;

/// <summary>
/// This is just for educational purposes, it is considered as legacy model
/// of asynchronous programming.
/// Now highly recommended is async-await pattern and TPL library.
/// </summary>
public class AsyncPatternsTestArea
{
    public byte[] _buffer;
    private const int InputReportLength = 1024;
    private FileStream _fileStream;

    public void BeginReadAsync()
    {
        _buffer = new byte[InputReportLength];
        _fileStream = File.OpenRead(@"C:\Users\MT\Desktop\Lista TODO.txt");
        _fileStream.BeginRead(_buffer, 0, InputReportLength, EndReadAsync, _buffer);
    }

    public void EndReadAsync(IAsyncResult result)
    {
        _fileStream.EndRead(result);
        var buffer = result.AsyncState as byte[];

        Console.WriteLine(Encoding.UTF8.GetString(buffer));
    }

}
