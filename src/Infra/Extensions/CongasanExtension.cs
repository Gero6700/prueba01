namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class CongasanExtension {
    public static CancellationPolicyLine ToCancellationPolicyLine(this Congasan congasan) {
        var line =  new CancellationPolicyLine {
            Code = congasan.Code,
            From = DateTimeHelper.ConvertYYYYMMDDToDatetime(congasan.C6fec1),
            To = DateTimeHelper.ConvertYYYYMMDDToDatetime(congasan.C6fec2),
            ReleaseDays = congasan.C6gcdi,
            ReleaseHours = congasan.C6gcho,
            PenaltyNights = congasan.C6gcno,
            PenaltyPercent = congasan.C6gcpo,
            PenaltyAmount = congasan.C6gcim,
            ApplicationMargin = congasan.C6marg,
            ApplicationType = congasan.C6medi.ToUpper() == "S" ? CancellationPolicyApplicationType.Avarage : CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = congasan.C6ofer.ToUpper() == "S" ? true: false,
            ApplyIfInsurance = congasan.C6segu.ToUpper() == "S" ? true: false,
            RefundAsBonus = congasan.C6bono.ToUpper() == "S" ? true: false
        };

        if (congasan.OriginType == OriginType.Contract) {
            line.ContractClients.Add(congasan.OriginCode);
        } else if (congasan.OriginType == OriginType.Offer) {
            line.OffersAndSuplements.Add(congasan.OriginCode);
        }

        return line;
    }
}
