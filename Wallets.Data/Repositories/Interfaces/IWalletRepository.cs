using Wallets.Models;
using Wallets.Models.Wrappers;

namespace Wallets.Data.Repositories.Interfaces;

public interface IWalletRepository
{
    Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter);
    Task<int> AddWalletAsync(Wallet wallet);
}