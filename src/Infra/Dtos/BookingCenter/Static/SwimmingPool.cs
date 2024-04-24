using System.Transactions;

namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class SwimmingPool : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public int NumberOfPools { get; set; }
    public int Capacity { get; set; }
    public decimal Surface { get; set; }
    public List<Translation> Translations { get; set; } = [];
    public List<Image> Images { get; set; } = [];
}
