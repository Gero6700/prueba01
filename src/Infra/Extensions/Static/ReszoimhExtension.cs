namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ReszoimhExtension {
    public static StaticHotelTax ToHotelTax(this Reszoimh reszoim) {
        return new StaticHotelTax {
            HotelCode = reszoim.Zhhote,
            TaxCode = reszoim.Zhcod
        };
    }
}

