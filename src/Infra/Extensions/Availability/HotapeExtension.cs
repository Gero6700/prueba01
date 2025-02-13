namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class HotapeExtension {
    public static HotelSeasonsDto ToHotelSeasons(this Hotape hotape) {
        var seasons = hotape.Apfecs.Split(';')
            .Select(season => {
                var dates = season.Split('-');
                return new SeasonDto {
                    OpeningDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(dates[0]),
                    ClosingDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(dates[1])
                };
            })
            .ToList();

        return new HotelSeasonsDto {
            HotelCode = hotape.Aphote.ToString(),
            Seasons = seasons
        };
    }
}