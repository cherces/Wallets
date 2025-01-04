using Wallets.Services;
using Wallets.Services.Interfaces;

namespace Wallets.Extensions;

public static class ApiExtensions
{
    public static void AddApiClients(this IServiceCollection services)
    {
        services.AddHttpClient<IWalletApiService, WalletApiService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5067/");
        });

        services.AddHttpClient<INethereumApiService, NethereumApiService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5180/");
        });
    }
}