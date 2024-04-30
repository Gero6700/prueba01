namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class OfferAndSupplementConfiguration : IAggregateRoot {
    public int FreeDays { get; set; }
    public string RoomTypeCodeToCalculatePrice { get; set; } = string.Empty;
    public string RegimeTypeCodeToCalculatePrice { get; set; } = string.Empty;
    public ApplyStayPriceType ApplyStayPriceType { get; set; }
    public decimal ApplyStayPrice { get; set; }
    public ApplyStayPriceType ApplyRegimePriceType { get; set; }
    public decimal ApplyRegimePrice { get; set; }
    public decimal DiscountAmount { get; set; }
    public TypeOfPayment DicountAmountType { get; set; }
    public DiscountTargetType DiscountTarget { get; set; }
    public DiscountScopeType DiscountScope { get; set; }
}
