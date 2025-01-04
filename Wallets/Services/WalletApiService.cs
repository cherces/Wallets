using Microsoft.AspNetCore.Mvc;
using Wallets.Models;
using Wallets.Models.Wrappers;
using Wallets.Services.Interfaces;

namespace Wallets.Services;

public class WalletApiService : IWalletApiService
{
    private readonly HttpClient _httpClient;

    public WalletApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter)
    {
        var response = await _httpClient.GetAsync("/api/wallet?" + 
                                                  $"Search={walletFilter.Search}" +
                                                  $"&Page={walletFilter.Page}" +
                                                  $"&PageSize={walletFilter.PageSize}");

        if (response.IsSuccessStatusCode) 
        {
            return await response.Content.ReadFromJsonAsync<PaginationResult<Wallet>>();
        }

        return new PaginationResult<Wallet>
        {
            Items = Enumerable.Empty<Wallet>(),
            Total = 0
        };    
    }

    public async Task<int> AddWalletAsync(Wallet wallet)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/wallet", wallet);
        var newWalletId = await responseMessage.Content.ReadFromJsonAsync<int>();
        return newWalletId;
    }
}