using Microsoft.AspNetCore.Mvc;
using Wallets.Models;
using Wallets.Models.Wrappers;

namespace Wallets.Services.Interfaces;

public interface IWalletApiService
{ 
    public Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter);
    public Task<int> AddWalletAsync(Wallet wallet);
}