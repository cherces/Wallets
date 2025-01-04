using Wallets.Logic.Services.Interfaces;
using Wallets.Models;
using Wallets.Data.Repositories.Interfaces;
using Wallets.Models.Wrappers;

namespace Wallets.Logic.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter)
    {
        return await _walletRepository.GetWalletsAsync(walletFilter);
    }

    public async Task<int> AddWalletAsync(Wallet wallet)
    {
        return await _walletRepository.AddWalletAsync(wallet);
    }
}