namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class OfferAndSupplementGroup {
    public string Code { get; set; } = string.Empty;
    public DateTime ApplyFrom { get; set; }
    public DateTime ApplyTo { get; set; }
    public List<string> ContractClients { get; set; } = new List<string>();
}
