﻿namespace MultiShopProject.WebUI.Services.StatisticServices.UserStatisticServices;

public interface IUserStatisticService
{
    Task<int> GetUserCount();
}
