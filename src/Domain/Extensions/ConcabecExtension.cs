using System.Globalization;

namespace Senator.As400.Cloud.Sync.Application.Extensions;
public static class ConcabecExtension {
    public static Contract ToContract(this Concabec concabec) {

        return new Contract {
            Code = concabec.Cohote + concabec.Cocont + concabec.Cofec1 + concabec.Covers,
            Description = concabec.Codesc,
            ValidDateFrom = ConvertJulianDateToDateTime(concabec.Cofec1),
            ValidDateTo = ConvertJulianDateToDateTime(concabec.Cofec1),
            TaxIncluded = string.Equals(concabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = concabec.Coftop != 0 ? ConvertIntegerToDatetime(concabec.Coftop) : null,
            DepositAmount = concabec.Codpto,
            DepositType = concabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = concabec.Cohote,
            CurrencyCode = concabec.Comone.ToString(),
            Market = concabec.Codmerca
        };
    }
    public static ContractClient ToContractClient(this Concabec concabec) {
        return new ContractClient {
            Code =string.Concat(concabec.Coagen, concabec.Cosucu, concabec.Coagcl, concabec.Cosucl),
            MinAgeOfBabies = concabec.Ceinmi,
            MaxAgeOfBabies = concabec.Cenima,
            MinAgeOfChildren = concabec.Cenimi,
            MaxAgeChildren = concabec.Cenima,
            MinAgeOfTeenagers = concabec.D4desd,
            MaxAgeOfTeenagers = concabec.D4hast,
            ExpiredDate = concabec.Cofext != 0 ? ConvertIntegerToDatetime(concabec.Cofext) : null,
            Comission = concabec.Cocoag,
            ComissionType = concabec.Cobaco == "B" ? IncomeType.Net : IncomeType.Pvp,
            ContractCode = concabec.Cohote + concabec.Cocont + concabec.Cofec1 + concabec.Covers,
            ClientCode = concabec.Idusuario.ToString()
        };
    }

    private static DateTime ConvertJulianDateToDateTime(int julianDate) {
        var year = julianDate / 1000;
        var dayOfYear = julianDate % 1000;
        var date = DateTime.MinValue;

        if (dayOfYear >= 1 && dayOfYear <= (DateTime.IsLeapYear(year) ? 366 : 365)) {
            date = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
        }

        return date;
    }

    private static DateTime? ConvertIntegerToDatetime(int integerDate) {
        DateTime date;
        if (DateTime.TryParseExact(integerDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
            return date;
        }
        else {
            return null;
        }
    }

}
