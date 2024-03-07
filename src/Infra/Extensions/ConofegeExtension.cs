using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConofegeExtension{
    public static OfferAndSupplement ToOfferAndSupplement(this Conofege conofege) {
        return new OfferAndSupplement {
            Code = conofege.Offec.ToString(),
            Type = OfferSupplementType.Offer,
            ApplyFrom = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec),
            ApplyTo = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2),
            ApplyOrder = null,
            DepositAmount = conofege.Ofdpto,
            DepositType = PaymentType.Fixed,
            DepositBeforeDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Offtop),
            ModificationCostsAmount = 0,
            Conditions = [],
            Configurations = []
        };
    }
}
