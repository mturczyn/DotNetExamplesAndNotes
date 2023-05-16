using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;

public class RealTimeDataHub : Hub
{
    private readonly RealTimeDataStreamWriter _realTimeDataStreamWriter;

    public RealTimeDataHub(RealTimeDataStreamWriter realTimeDataStreamWriter)
    {
        _realTimeDataStreamWriter = realTimeDataStreamWriter;
    }

    public ChannelReader<CurrencyStreamItem> CurrencyValues()
    {
        var channel = Channel.CreateUnbounded<CurrencyStreamItem>();

        _realTimeDataStreamWriter.AddCurrencyListener(Context.ConnectionId, channel.Writer);

        return channel.Reader;
    }

    public ChannelReader<DataItem> Variation()
    {
        var channel = Channel.CreateUnbounded<DataItem>();

        _realTimeDataStreamWriter.AddVariationListener(Context.ConnectionId, channel.Writer);

        return channel.Reader;
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _realTimeDataStreamWriter.RemoveListeners(Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }
}
