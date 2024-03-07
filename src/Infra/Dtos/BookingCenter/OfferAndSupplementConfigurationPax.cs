namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;
public class OfferAndSupplementConfigurationPax{
    public int PaxOrder { get; set; }
    public PaxType PaxType { get; set; }
    public ScopeType Scope { get; set; }
    public decimal AgeFrom { get; set; }
    public decimal AgeTo { get; set; }
    public decimal Amount { get; set; }
    public PaymentType AmountType { get; set; }
}
