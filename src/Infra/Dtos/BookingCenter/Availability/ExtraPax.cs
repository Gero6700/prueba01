namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class ExtraPax {
    public int PaxOrder { get; set; }
    public PaxType PaxType { get; set; }
    public decimal AgeFrom { get; set; }
    public decimal AgeTo { get; set; }
    public decimal Amount { get; set; }
    public TypeOfPayment AmountType { get; set; }
}
