using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;
using Nethereum.Util;


namespace NethereumAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountBalanceController : Controller
    {
        private readonly Web3 _web3;
        private static readonly AddressUtil AddressUtil = new AddressUtil();

        public AccountBalanceController(IConfiguration configuration)
        {
            var infuraApiKey = configuration["Infura:ApiKey"];
            _web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
        }
        
        [HttpGet("{address}")]
        public async Task<IActionResult> GetByAddressAsync(string address)
        {
            if (!IsValidEthereumAddress(address))
            {
                return BadRequest("Неверный адрес Ethereum");
            }

            try
            {
                var balance = await _web3.Eth.GetBalance.SendRequestAsync(address);
                return Ok(Web3.Convert.FromWei(balance.Value));
            }
            catch (Exception e)
            {
                // добавить логгирование???
                return StatusCode(500, e.Message);
            }
        }

        private bool IsValidEthereumAddress(string address)
        {
            return AddressUtil.IsChecksumAddress(address);
        }
    }
}

