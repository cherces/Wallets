using Microsoft.EntityFrameworkCore;
using Wallets.Models;
using Wallets.Data.Repositories.Interfaces;
using Wallets.Models.Wrappers;

namespace Wallets.Data.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly ApplicationDbContext _context;

    public WalletRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginationResult<Wallet>> GetWalletsAsync(Wallet walletFilter)
    {
        var query = _context.Wallets.AsQueryable();
        var count = await query.CountAsync();

        if (walletFilter.Search != null)
        {
            query = query.Where(q => q.Address.Contains(walletFilter.Search));
        }
        
        var wallets = await query.Skip((walletFilter.Page - 1) * walletFilter.PageSize)
            .Take(walletFilter.PageSize)
            .ToListAsync();
        
        return new PaginationResult<Wallet>()
        {
            Items = wallets,
            Total = count
        };
    }

    public async Task<int> AddWalletAsync(Wallet wallet)
    {
        wallet.Id = (int)(DateTime.UtcNow.Ticks % int.MaxValue);
        var newWallet = await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return newWallet.Entity.Id;
    }
}