namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class ExtraPaxDto {
    public int PaxOrder { get; init; }
    public required PaxType PaxType { get; init; }
    public decimal? AgeFrom { get; init; }
    public decimal? AgeTo { get; init; }
    public decimal Amount { get; init; }
    public required TypeOfPayment AmountType { get; init; }
}