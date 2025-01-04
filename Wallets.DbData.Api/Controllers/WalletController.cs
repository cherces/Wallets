using Microsoft.AspNetCore.Mvc;
using Wallets.Logic.Services.Interfaces;
using Wallets.Models;

namespace Wallets.DbData.Api.Controllers
{
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletsAsync([FromQuery] Wallet walletFilter)
        {
            var wallets = await _walletService.GetWalletsAsync(walletFilter);
            return Ok(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalletAsync([FromBody] Wallet wallet)
        {
            try
            {
                var newWalletId = await _walletService.AddWalletAsync(wallet);
                return Ok(newWalletId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}