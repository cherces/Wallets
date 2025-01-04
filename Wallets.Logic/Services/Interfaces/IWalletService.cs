using Wallets.Models;
using Wallets.Models.Wrappers;

namespace Wallets.Logic.Services.Interfaces;

public interface IWalletService
{
    public Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter);
    public Task<int> AddWalletAsync(Wallet wallet);
}