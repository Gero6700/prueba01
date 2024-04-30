namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class OfferAndSupplement : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public OfferSupplementType Type { get; set; }
    public DateTime ApplyFrom { get; set; }
    public DateTime ApplyTo { get; set; }
    public int? ApplyOrder { get; set; }
    public decimal DepositAmount { get; set; }
    public TypeOfPayment DepositType { get; set; }
    public DateTime? DepositBeforeDate { get; set; }
    public decimal ModificationCostsAmount { get; set; }
    public List<string> ContractClients { get; set; } = new List<string>();
    public List<OfferAndSupplementCondition> Conditions { get; set; } = new List<OfferAndSupplementCondition>();
    public List<OfferAndSupplementConfiguration> Configurations { get; set; } = new List<OfferAndSupplementConfiguration>();
}
