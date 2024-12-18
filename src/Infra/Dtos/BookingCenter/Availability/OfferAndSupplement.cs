namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class OfferAndSupplement : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public OfferSupplementType Type { get; set; }
    public DateTime ApplyFrom { get; set; }
    public DateTime ApplyTo { get; set; }
    public int? ApplyOrder { get; set; }
    public decimal? DepositAmount { get; set; }
    public TypeOfPayment? DepositType { get; set; }
    public DateTime? DepositBeforeDate { get; set; }
    public decimal? ModificationCostsAmount { get; set; }
    public List<string> ContractClients { get; set; } = [];
    public OfferAndSupplementCondition Condition { get; set; } = new OfferAndSupplementCondition();
    public OfferAndSupplementConfiguration Configuration { get; set; } = new OfferAndSupplementConfiguration();
}
