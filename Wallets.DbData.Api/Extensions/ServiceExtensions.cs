using Wallets.Logic.Services;
using Wallets.Logic.Services.Interfaces;

namespace Wallets.DbData.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IWalletService, WalletService>();
    }
}