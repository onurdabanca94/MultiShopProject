using Microsoft.AspNetCore.SignalR;
using MultiShopProject.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShopProject.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShopProject.SignalRRealTimeApi.Hubs;

public class SignalRHub : Hub
{
    private readonly ISignalRCommentService _signalRCommentService;
    private readonly ISignalRMessageService _signalRMessageService;

    public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
    {
        _signalRCommentService = signalRCommentService;
        _signalRMessageService = signalRMessageService;
    }

    public async Task SendStatisticCount(string id)
    {
        var getTotalCommentCount = _signalRCommentService.GetTotalCommentCount();
        await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

        var getTotalMessageCount = _signalRMessageService.GetTotalMessageCountByReceiverId(id);
        await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
    }
}
