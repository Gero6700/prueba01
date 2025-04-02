namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class HotelExtension
{
    public static StaticHotelDto ToHotelDto(this Hotel hotel)
    {
        return new StaticHotelDto
        {
            Code = hotel.CodigoInterno.ToString(),
            LocationCode = hotel.CodigoProvinciaIso, //TODO: Es nuevo, averiguar el mapeo
            Name = hotel.NombreHotel,
            Category = hotel.CodigoCategoria,
            CodeType = hotel.NombreMarcaComercial,
            Type = hotel.CodigoTipoHotel,
            Director = hotel.Director,
            RoomsNumber = hotel.NumeroHabitaciones,
            FloorsNumber = hotel.NumeroPlantas,
            ConstructionYear = hotel.AnioConstruccion,
            HasSpecialTaxes = false, // TODO: Es nuevo, averiguar el mapeo
            HotelChain = new StaticHotelChainDto //TODO: va en la cabecera
            {
                Code = "DefaultCode", // Set appropriate value
                Active = true // Set appropriate value
            },
            HotelAddress = new StaticHotelAddressDto
            {
                Country = hotel.EsPais,
                CountryCode = hotel.CodigoPaisIso,
                StateProvince = hotel.NombreProvincia,
                StateProvinceCode = hotel.CodigoProvinciaIso,
                City = hotel.NombreLocalidad,
                CityCode = hotel.CodigoLocalidad,
                StreetAddress = hotel.Domicilio,
                PostalCode = hotel.CodigoPostal,
                Latitude = double.TryParse(hotel.GmapsLatitud, out var lat) ? lat : null,
                Longitude = double.TryParse(hotel.GmapsLongitud, out var lon) ? lon : null,
            },
            HotelTimeZone = new StaticHotelTimeZoneDto //TODO: Es nuevo, averiguar el mapeo. Tambien está en availability
            {
                GreenwichMeanTime = "GMT+01:00:00"
            },
            HotelContact = new StaticHotelContactDto
            {
                Phone = hotel.Telefono,
                Fax = hotel.Fax,
                Email = hotel.Email,
                Web = hotel.Web,
            },
            HotelPaxAgesConfiguration = new StaticHotelPaxAgesConfigurationDto
            {
                TeenagerMinAge = hotel.EdadMaxNino + 0.01m,
                TeenagerMaxAge = 17.99m,
                ChildMinAge = hotel.EdadMinNino,
                ChildMaxAge = hotel.EdadMaxNino,
                BabyMinAge = hotel.EdadMinBebe,
                BabyMaxAge = hotel.EdadMaxBebe
            },
            HotelTranslations = GetTranslations(hotel),
            HotelImages = hotel.Imagenes.ToImageDto<StaticHotelImageDto>(),
            Rooms = hotel.Habitaciones.ToRoomDto(hotel.Imagenes, hotel.HabitacionesCamas, hotel.HabitacionesServicios),
            Meals = hotel.Regimenes.ToMealDto(), 
            Services = hotel.Servicios.ToServiceDto(),
            SwimmingPools = hotel.Piscinas.ToSwimmingPoolDto(hotel.PiscinasImagenes),
            Salons = hotel.Salones.ToSalonDto(),
        };
    }

    private static List<StaticHotelTranslationDto> GetTranslations(Hotel estHotel)
    {
        var translations = new List<StaticHotelTranslationDto>();

        var shortDescriptions = new Dictionary<Language, string> {
                        { Language.Es, estHotel.EsEntradilla },
                        { Language.En, estHotel.EnEntradilla },
                        { Language.Fr, estHotel.FrEntradilla },
                        { Language.De, estHotel.DeEntradilla },
                        { Language.Pt, estHotel.PtEntradilla }
                    };

        var largeDescriptions = new Dictionary<Language, string> {
                        { Language.Es, estHotel.EsDescripcion },
                        { Language.En, estHotel.EnDescripcion },
                        { Language.Fr, estHotel.FrDescripcion },
                        { Language.De, estHotel.DeDescripcion },
                        { Language.Pt, estHotel.PtDescripcion }
                    };

        var locationDescriptions = new Dictionary<Language, string> {
                        { Language.Es, estHotel.EsSituacion },
                        { Language.En, estHotel.EnSituacion },
                        { Language.Fr, estHotel.FrSituacion },
                        { Language.De, estHotel.DeSituacion },
                        { Language.Pt, estHotel.PtSituacion }
                    };

        foreach (var language in Enum.GetValues<Language>())
        {
            translations.Add(new StaticHotelTranslationDto
            {
                LanguageIsoCode = language.GetIsoCode(),
                ShortDescription = shortDescriptions[language],
                LargeDescription = largeDescriptions[language],
                LocationDescription = locationDescriptions[language]
            });
        }

        return translations;
    }
}
