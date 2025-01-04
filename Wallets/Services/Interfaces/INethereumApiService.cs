namespace Wallets.Services.Interfaces;

public interface INethereumApiService
{
    public Task<decimal> GetBalanceAsync (string address);
}