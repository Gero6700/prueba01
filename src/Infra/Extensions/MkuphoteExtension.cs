namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class MkuphoteExtension {
    public static MarkupHotel ToMarkupHotel(this Mkuphote mkuphote) {
        return new MarkupHotel {
            HotelCode = mkuphote.Mkhidc.ToString(),
            MarkupCode = mkuphote.Mkhhot.ToString()
        };
    }
}
