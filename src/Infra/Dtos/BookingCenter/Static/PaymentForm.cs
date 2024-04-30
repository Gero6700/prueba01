namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class PaymentForm{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CreditOrPrepayType CreditOrPrepay { get; set; }
}
