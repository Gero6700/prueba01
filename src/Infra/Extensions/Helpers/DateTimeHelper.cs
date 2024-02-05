namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers; 

public static class DateTimeHelper {
    public static DateTime ConvertJulianDateToDateTime(int julianDate) {
        var year = julianDate / 1000;
        var dayOfYear = julianDate % 1000;
        var date = DateTime.MinValue;
        
        if (dayOfYear >= 1 && year >= 1 && year <= 9999 && dayOfYear <= (DateTime.IsLeapYear(year) ? 366 : 365)) {
            date = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
        }

        return date;
    }

    public static DateTime? ConvertIntegerToNullableDatetime(int integerDate) {
        if (DateTime.TryParseExact(integerDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)) {
            return date;
        }

        return null;

    }

    

    //    public static bool IsValidJulianDate(int integerDate) {
    //        if (ConvertJulianDateToDateTime(integerDate) is not DateTime.MinValue) {
    //            return true;
    //        }
    //        return false;
    //    }
}