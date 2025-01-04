using System.Globalization;
using Wallets.Services.Interfaces;

namespace Wallets.Services;

public class NethereumApiService : INethereumApiService
{
    private readonly HttpClient _httpClient;

    public NethereumApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetBalanceAsync(string address)
    {
        var response = await _httpClient.GetAsync($"api/AccountBalance/{address}");
        var content = await response.Content.ReadAsStringAsync();
        
        if (decimal.TryParse(content, NumberStyles.Number, CultureInfo.InvariantCulture, out var balance))
        {
            return balance;
        }
        
        return 0.00m;
    }
}