using Wallets.Services;
using Wallets.Services.Interfaces;

namespace Wallets.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IWalletApiService, WalletApiService>();
        services.AddScoped<INethereumApiService, NethereumApiService>();
    }
}