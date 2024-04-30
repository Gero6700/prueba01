namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ForpagoExtension {
    public static PaymentType ToPaymentType(this Forpago forpago) {
        return new PaymentType {
            Code = forpago.Codpag,
            Description = forpago.Despag,
            CreditOrPrepay = forpago.Precre == "C" ? CreditOrPrepayType.Credit : CreditOrPrepayType.Prepay
        };
    }
}
