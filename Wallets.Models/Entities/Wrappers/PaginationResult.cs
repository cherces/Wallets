namespace Wallets.Models.Wrappers;

public class PaginationResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Total { get; set; }
}