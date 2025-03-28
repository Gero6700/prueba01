using System.Transactions;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstHotelExtension
{
    public static StaticHotelDto ToHotel(this Hotel estHotel)
    {
        return new StaticHotelDto
        {
            Code = estHotel.CodigoInterno.ToString(),
            Name = estHotel.NombreHotel,
            Category = estHotel.CodigoCategoria,
            HasSpecialTaxes = false, // Set appropriate value
            HotelChain = new StaticHotelChainDto
            {
                Code = "DefaultCode", // Set appropriate value
                Active = true // Set appropriate value
            },
            HotelAddress = new StaticHotelAddressDto(), // Set appropriate value
            HotelTimeZone = new StaticHotelTimeZoneDto
            {
                GreenwichMeanTime = "GMT" // Set appropriate value
            },
            HotelPaxAgesConfiguration = new StaticHotelPaxAgesConfigurationDto(), // Set appropriate value
            HotelTranslations = new List<StaticHotelTranslationDto>(), // Set appropriate value
            Rooms = new List<RoomDto>(), // Set appropriate value
            Meals = new List<StaticMealDto>() // Set appropriate value
        };
    }
}
