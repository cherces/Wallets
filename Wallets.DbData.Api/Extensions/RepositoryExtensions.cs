using Wallets.Data.Repositories;
using Wallets.Data.Repositories.Interfaces;

namespace Wallets.DbData.Api.Extensions;

public static class RepositoryExtensions
{
    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWalletRepository, WalletRepository>();
    }
}