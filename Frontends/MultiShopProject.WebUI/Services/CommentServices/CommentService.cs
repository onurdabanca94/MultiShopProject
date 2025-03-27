﻿using MultiShopProject.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShopProject.WebUI.Services.CommentServices;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
    {
        var responseMessage = await _httpClient.GetAsync("Comments/CommentListByProductId/" + id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }

    public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments", createCommentDto);
    }

    public async Task DeleteCommentAsync(string id)
    {
        await _httpClient.DeleteAsync("Comments?id=" + id);
    }



    public async Task<List<ResultCommentDto>> GetAllCommentsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("Comments");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }

    public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("Comments/" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
        return values;
    }

    public async Task<int> GetActiveCommentCount()
    {
        var responseMessage = await _httpClient.GetAsync("Comments/GetActiveCommentCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }

    public async Task<int> GetPassiveCommentCount()
    {
        var responseMessage = await _httpClient.GetAsync("Comments/GetPassiveCommentCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }

    public async Task<int> GetTotalCommentCount()
    {
        var responseMessage = await _httpClient.GetAsync("Comments/GetTotalCommentCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }

    public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comments", updateCommentDto);
    }
}
