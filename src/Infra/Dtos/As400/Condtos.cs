namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Condtos{
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public required string Code { get; set; } = string.Empty;
    public required string D4tipa { get; set; } = string.Empty;
    public required string D4tdto { get; set; } = string.Empty;
    public required decimal D4desd { get; set; }
    public required decimal D4has { get; set; }
    public required decimal D4dtos { get; set; }
    public required string PeriodPricingCode { get; set; } = string.Empty;
}
