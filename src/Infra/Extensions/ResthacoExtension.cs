namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ResthacoExtension {
    public static OcuppancyRate ToOcuppancyRate(this Resthaco resthaco) {
        return new OcuppancyRate {
            Code = resthaco.Cocod,
            MinAdult = resthaco.Cminad,
            MinTeen = resthaco.Cminat,
            MinChild = resthaco.Cminni,
            MinInfant = resthaco.Cminin,
            MaxAdult = resthaco.Cmaxad,
            MaxTeen = resthaco.Cmaxat,
            MaxChild = resthaco.Cmaxni,
            MaxScore = resthaco.Cmaxto,
            MinScore = resthaco.Cminto
        };
    }
}
