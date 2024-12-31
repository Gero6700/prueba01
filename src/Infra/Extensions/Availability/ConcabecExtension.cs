using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ConcabecExtension {
    public static Contract ToContract(this Concabec concabec) {
        return new Contract {
            Code = concabec.ContractCode,
            ClosingSales = false,
            Description = concabec.Codesc,
            ValidDateFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec1),
            ValidDateTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec2),
            TaxIncluded = string.Equals(concabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = concabec.Coftop != 0 ? DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(concabec.Coftop) : null,
            DepositAmount = concabec.Codpto,
            DepositType = concabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = concabec.Cohote.ToString(),
            CurrencyIsoCode = concabec.Dinom2,
            MarketCode = concabec.Codmerca
        };
    }

    public static ContractClient ToContractClient(this Concabec concabec) {
        return new ContractClient {
            Code = concabec.ContractClientCode,
            ClosingSales = false,
            MinAgeOfBabies = concabec.Ceinmi,
            MaxAgeOfBabies = concabec.Ceinma,
            MinAgeOfChildren = concabec.Cenimi,
            MaxAgeChildren = concabec.Cenima,
            MinAgeOfTeenagers = concabec.D4desd,
            MaxAgeOfTeenagers = concabec.D4hast,
            ExpiredDate = concabec.Cofext != 0 ? DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(concabec.Cofext) : null,
            Comission = concabec.Cocoag,
            IsPvp = concabec.Cocoag == 0,
            CancellationGuarantee = concabec.Cogcpo,
            CancellationGuaranteeIsCommissionable = concabec.Cocose == "S",
            ContractCode = concabec.ContractCode,
            ClientCode = concabec.Idusuario.ToString()
        };
    }
}
