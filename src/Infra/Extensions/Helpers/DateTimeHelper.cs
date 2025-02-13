namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers; 

public static class DateTimeHelper {
    //public static DateTime ConvertJulianDateToDateTime(int julianDate) {
    //    var date = DateTime.MinValue;

    //    if (julianDate.ToString().Length == 7) {
    //        var year = julianDate / 1000;
    //        var dayOfYear = julianDate % 1000;

    //        if (dayOfYear >= 1 && year >= 1 && year <= 9999 && dayOfYear <= (DateTime.IsLeapYear(year) ? 366 : 365)) {
    //            date = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
    //        }
    //    }      

    //    return date;
    //}

    public static DateTime? ConvertYYYYMMDDToNullableDatetime(int stringDate) {
        if (DateTime.TryParseExact(stringDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return null;

    }

    public static DateTime ConvertYYYYMMDDToDatetime(int integerDate) {
        if (DateTime.TryParseExact(integerDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return DateTime.MinValue;

    }

    public static DateTime ConvertYYMMDDToDatetime(int integerDate) {
        if (DateTime.TryParseExact(integerDate.ToString(), "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return DateTime.MinValue;
    }

    public static DateTime? ConvertYYYYMMDDToNullableDatetime(string stringDate) {
        if (DateTime.TryParseExact(stringDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return null;

    }

    public static DateTime ConvertYYYYMMDDToDatetime(string stringDate) {
        if (DateTime.TryParseExact(stringDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return DateTime.MinValue;
    }
}