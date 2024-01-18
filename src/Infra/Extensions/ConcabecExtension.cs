namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;

public static class ConcabecExtension {
    public static Contract ToContract(this Concabec concabec) {
        return new Contract {
            Code = concabec.GetNewCode,
            Description = concabec.Codesc,
            ValidDateFrom = DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec1),
            ValidDateTo = DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec2),
            TaxIncluded = true,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = concabec.Coftop != 0 ? DateTimeHelper.ConvertIntegerToDatetime(concabec.Coftop) : null,
            DepositAmount = concabec.Codpto,
            DepositType = concabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = concabec.Cohote,
            CurrencyCode = concabec.Comone.ToString(),
            Market = concabec.Codmerca
        };
    }

    public static ContractClient ToContractClient(this Concabec concabec) {
        return new ContractClient {
            Code = $"{concabec.Coagen}{concabec.Cosucu}{concabec.Coagcl}{concabec.Cosucl}",
            MinAgeOfBabies = concabec.Ceinmi,
            MaxAgeOfBabies = concabec.Ceinma,
            MinAgeOfChildren = concabec.Cenimi,
            MaxAgeChildren = concabec.Cenima,
            MinAgeOfTeenagers = concabec.D4desd,
            MaxAgeOfTeenagers = concabec.D4hast,
            ExpiredDate = concabec.Cofext != 0 ? DateTimeHelper.ConvertIntegerToDatetime(concabec.Cofext) : null,
            Comission = concabec.Cocoag,
            ComissionType = concabec.Cobaco == "B" ? IncomeType.Net : IncomeType.Pvp,
            ContractCode = concabec.GetNewCode,
            ClientCode = concabec.Idusuario.ToString()
        };
    }
}
