namespace DotNetExamplesAndNotes.ConsoleApp.AsyncPatterns;

public class AsyncOperationsWithIterators
{
    public static async Task AsyncWithIteratorsExample()
    {

        (FileStream Source, FileStream Destination)[] streams = null;

        try
        {
            streams = Enumerable.Range(0, 100)
                .Select(x => GetFileInAndOutStreams())
                .ToArray();

            if (false)
            {
                var tasks = streams
                    .Select(x => CopyToStreamAsync(x.Source, x.Destination))
                    .ToArray();

                await Task.WhenAll(tasks);
            }
            else
            {
                foreach (var item in streams)
                {
                    await CopyToStreamAsync(item.Source, item.Destination);
                }
            }
        }
        finally
        {
            if (streams is not null)
            {
                foreach (var item in streams)
                {
                    item.Source?.Dispose();
                    item.Destination?.Dispose();
                }
            }
        }
    }

    private static Task CopyToStreamAsync(Stream source, Stream destination)
    {
        return IterateAsync(Impl(source, destination));

        static IEnumerable<Task> Impl(Stream source, Stream destination)
        {
            var buffer = new byte[0x1000];
            while (true)
            {
                Task<int> read = source.ReadAsync(buffer, 0, buffer.Length);
                yield return read;
                var numRead = read.Result;
                if (numRead <= 0)
                {
                    break;
                }
                Task write = destination.WriteAsync(buffer, 0, numRead);
                yield return write;
                write.Wait();
            }
        }
    }

    static Task IterateAsync(IEnumerable<Task> tasks)
    {
        var tcs = new TaskCompletionSource();
        IEnumerator<Task> e = tasks.GetEnumerator();
        void Process()
        {
            try
            {
                if (e.MoveNext())
                {
                    e.Current.ContinueWith(t => Process());
                    return;
                }
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
                return;
            }
            tcs.SetResult();
        }
        Process();

        return tcs.Task;
    }

    static (FileStream Source, FileStream Destination) GetFileInAndOutStreams()
    {
        const string baseDirectory = @"C:/users/mt/desktop/asynctests/";

        if (!Directory.Exists(baseDirectory))
        {
            Directory.CreateDirectory(baseDirectory);
        }

        var sourcePath = Path.Combine(baseDirectory, Guid.NewGuid() + ".txt");
        var outputPath = Path.Combine(baseDirectory, Guid.NewGuid() + ".txt");
        File.WriteAllText(sourcePath, "bla bla bla");

        var source = File.OpenRead(Path.Combine(baseDirectory, sourcePath));
        var destination = File.OpenWrite(Path.Combine(baseDirectory, outputPath));

        return (Source: source, Destination: destination);
    }
}
