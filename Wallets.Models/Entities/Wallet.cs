using System.ComponentModel.DataAnnotations.Schema;

namespace Wallets.Models;

public class Wallet : FilterBase
{
    public int Id { get; set; }
    public string Address { get; set; }
    [NotMapped]
    public decimal Balance { get; set; }
}