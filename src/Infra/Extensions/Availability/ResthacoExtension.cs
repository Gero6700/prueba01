namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ResthacoExtension {
    public static OccupancyRateDto ToOccupancyRate(this Resthaco resthaco) {
        return new OccupancyRateDto {
            Code = resthaco.Cocod,
            MinAdult = resthaco.Cminad,
            MinTeen = resthaco.Cminat,
            MinChild = resthaco.Cminni,
            MinBaby = resthaco.Cminin,
            MaxBaby = resthaco.Cmaxin,
            MaxAdult = resthaco.Cmaxad,
            MaxTeen = resthaco.Cmaxat,
            MaxChild = resthaco.Cmaxni,
            MaxScore = resthaco.Cmaxto,
            MinScore = resthaco.Cminto
        };
    }
}
