using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Wallets.Models;

public class FilterBase
{
    [NotMapped, JsonIgnore]
    public int Page { get; set; } = 1;
    [NotMapped, JsonIgnore]
    public int PageSize { get; set; } = 20;
    [NotMapped, JsonIgnore]
    public string Search { get; set; } = "";
    [NotMapped, JsonIgnore]
    public string SortBy { get; set; } = "";
    [NotMapped, JsonIgnore]
    public string SortOrder { get; set; } = "";
}