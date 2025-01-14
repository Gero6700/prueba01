namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CongasanExtension {
    public static CancellationPolicyDto ToCancellationPolicyLine(this Congasan congasan) {
        var line = new CancellationPolicyDto {
            Code = congasan.Code,
            ReleaseDays = congasan.C6gcdi,
            ReleaseHours = congasan.C6gcho,
            PenaltyNights = congasan.C6gcno,
            PenaltyPercent = congasan.C6gcpo,
            PenaltyAmount = congasan.C6gcim,
            ApplicationMargin = congasan.C6marg,
            ApplicationType = congasan.C6medi.ToUpper() == "S" ? CancellationPolicyApplicationType.Avarage : CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = congasan.C6ofer.ToUpper() == "S" ? true : false,
            ApplyIfInsurance = congasan.C6segu.ToUpper() == "S" ? true : false,
            RefundAsBonus = congasan.C6bono.ToUpper() == "S" ? true : false,
            IntegrationContractCodes = congasan.OriginType == OriginType.Contract ? [congasan.OriginCode] : null,
            OfferSupplementCodes = congasan.OriginType == OriginType.Offer ? [congasan.OriginCode] : null
        };

        return line;
    }
}
