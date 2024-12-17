namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class OfferAndSupplementConfiguration : IAggregateRoot {
    public int? FreeDays { get; set; }
    public string? RoomTypeCodeToCalculatePrice { get; set; }
    public string? RegimeTypeCodeToCalculatePrice { get; set; }
    public ApplyStayPriceType? ApplyStayPriceType { get; set; }
    public decimal? ApplyStayPrice { get; set; }
    public ApplyStayPriceType? ApplyRegimePriceType { get; set; }
    public decimal? ApplyRegimePrice { get; set; }
    public decimal Amount { get; set; }
    public TypeOfPayment AmountType { get; set; }
    public DiscountTargetType Target { get; set; }
    public DiscountScopeType Scope { get; set; }
}
