namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ConcabecExtension {
    public static ContractHeaderDto ToContract(this Concabec concabec) {
        return new ContractHeaderDto {
            Code = concabec.ContractCode,
            Description = concabec.Codesc,
            ClosingSales = false,            
            ValidDateFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec1),
            ValidDateTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec2),
            TaxIncluded = string.Equals(concabec.Coiva, "I"),
            OrderedAges = TypeOfAgeOrdering.Asc,
            DepositDate = concabec.Coftop != 0 ? DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(concabec.Coftop) : null,
            DepositAmount = concabec.Codpto == 0 ? null : concabec.Codpto,
            DepositType = concabec.Codpto == 0 ? null : concabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            BabiesFree = true,
            HotelCode = concabec.Cohote.ToString(),
            CurrencyIsoCode = concabec.Dinom2,
            MarketCode = concabec.Codmerca
        };
    }

    public static IntegrationContractDto ToContractClient(this Concabec concabec) {
        return new IntegrationContractDto {
            Code = concabec.ContractClientCode,
            ClosingSales = false,
            MinAgeBaby = concabec.Ceinmi,
            MaxAgeBaby = concabec.Ceinma,
            MinAgeChild = concabec.Cenimi,
            MaxAgeChild = concabec.Cenima,
            MinAgeTeenager = concabec.D4desd > 0 ? concabec.D4desd : null,
            MaxAgeTeenager = concabec.D4hast > 0 ? concabec.D4hast : null,
            ExpiredDate = concabec.Cofext != 0 ? DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(concabec.Cofext) : null,
            Commission = concabec.Cocoag,
            IsPvp = concabec.Cocoag == 0,
            CancellationGuarantee = concabec.Cogcpo,
            CancellationGuaranteeIsCommissionable = concabec.Cocose == "S",
            ContractHeaderCode = concabec.ContractCode,
            IntegrationCode = concabec.Idusuario.ToString()
        };
    }
}
