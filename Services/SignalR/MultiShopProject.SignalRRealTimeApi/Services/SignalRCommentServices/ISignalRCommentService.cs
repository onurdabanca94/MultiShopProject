﻿namespace MultiShopProject.SignalRRealTimeApi.Services.SignalRCommentServices;

public interface ISignalRCommentService
{
    Task<int> GetTotalCommentCount();
}
