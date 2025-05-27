namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class HotelExtension
{
    public static IEnumerable<StaticHotelDto> ToHotelDtos(this IEnumerable<Hotel> hotels) {
        return hotels.Select(h => h.ToHotelDto());
    }

    public static StaticHotelDto ToHotelDto(this Hotel hotel)
    {
        var provinceIsoCode = GetProvinceIsoCode(hotel.CodigoProvincia);
       
        return new StaticHotelDto
        {
            Code = hotel.CodigoInterno.ToString(),
            LocationCode = provinceIsoCode, //TODO: Pendiente de ver si se mapea con provinciacode o poblacioncode
            Name = hotel.NombreHotel,
            Category = hotel.CodigoCategoria,
            CodeType = hotel.NombreMarcaComercial,
            Type = hotel.CodigoTipoHotel,
            Director = hotel.Director,
            RoomsNumber = hotel.NumeroHabitaciones,
            FloorsNumber = hotel.NumeroPlantas,
            ConstructionYear = hotel.AnioConstruccion,
            HasSpecialTaxes = false, // TODO: Es nuevo, averiguar el mapeo
            HotelAddress = new StaticHotelAddressDto
            {
                Country = hotel.EsPais,
                CountryCode = GetCountryIsoCode(hotel.CodigoPais),
                StateProvince = hotel.NombreProvincia,
                StateProvinceCode = provinceIsoCode,
                City = hotel.NombreLocalidad,
                CityCode = GetCityCode(provinceIsoCode, hotel.CodigoLocalidad), //Codigo iso provincia + codigo localidad ine: ES-AL-100
                StreetAddress = hotel.Domicilio,
                PostalCode = hotel.CodigoPostal,
                Latitude = double.TryParse(hotel.GmapsLatitud, out var lat) ? lat : null,
                Longitude = double.TryParse(hotel.GmapsLongitud, out var lon) ? lon : null,
            },
            HotelTimeZoneDescription = "Unknown", 
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
            MealCodes = hotel.RegimenesCodes.Select(r => r.ToString()), //.ToMealDto(), 
            ServiceCodes = !hotel.ServiciosIds.Any() ? null : hotel.ServiciosIds.Select(r => r.ToString()), //.ToServiceDto(),
            SwimmingPools = hotel.Piscinas.ToSwimmingPoolDto(hotel.PiscinasImagenes),
            Salons = hotel.Salones.ToSalonDto(hotel.SalonesImagenes),
        };
    }

    private static string GetCityCode(string provinceIsoCode, string cityCode) {
        var cityIneCode = GetCityINECode(cityCode);
        return string.IsNullOrEmpty(cityIneCode) ? provinceIsoCode
                    : string.IsNullOrEmpty(provinceIsoCode)
                        ? cityIneCode
                        : $"{provinceIsoCode}-{cityIneCode}";
    }

    private static string GetCityINECode(string city) {
        return city switch {
            "15" => "079", //Roquetas de mar
            "18" => "079", //Aguadulce - Roquetas de Mar
            "C23" => "100", //Vera
            "43" => "019", //Barcelona
            "4" => "012", //Cádiz
            "60" => "017", //Almuñecar
            "G1" => "087", //Granada    
            "D03" => "010", //Isla Canela - Ayamonte
            "F04" => "012", //Cartaya
            "9" => "079", //Madrid
            "11" => "025", //Benlamádena
            "13" => "051", //Estepona
            "17" => "069", //Marbella
            "D01" => "024", //Teguisse - Lanzarote
            "D02" => "028", //Puerto de la Cruz - Tenerife
            "V1" => "250", //Valencia
            "57" => "PP", //Puerto Plata - República Dominicana
            _ => string.Empty
        };
    }

    private static string GetCountryIsoCode(int countryCode) {
        return countryCode switch {
            33 => "FR", //Francia
            34 => "ES", //España
            44 => "GB", //REINO UNIDO
            49 => "DE", //Alemania
            52 => "MX", //Mejico
            212 => "MA", //Marruecos
            216 => "TN", //Tunez
            351 => "PT", //Portugal
            809 => "DO", //Republica dominicana
            _ => ""
        };
    }

    private static string GetProvinceIsoCode(int provinceCode) {
        return provinceCode switch {
            4 => "ES-AL", //Almería
            8 => "ES-B", //Barcelona
            11 => "ES-CA", //Cádiz
            18 => "ES-GR", //Granada
            21 => "ES-H", //Huelva
            28 => "ES-M", //Madrid
            29 => "ES-MA", //Málaga
            30 => "ES-MU", //Murcia
            35 => "ES-GC", //Lanzarote-Las Palmas
            38 => "ES-GC", //Tenerife-Las Palmas
            41 => "ES-SE", //Sevilla
            46 => "ES-V", //Valencia
            51 => "ES-PM", //Islas Baleares
            77 => "MX-YU", //Riviera Cancun
            73 => "MA-EH", //Dakhla
            50 => "TN-11", //Tunez
            53 => "DO-18", //Republica dominicana
            _ => string.Empty
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

        foreach (var language in Enum.GetValues<Language>()) {
            var shortDescription = shortDescriptions[language];
            var largeDescription = largeDescriptions[language];
            var locationDescription = locationDescriptions[language];

            if (string.IsNullOrEmpty(shortDescription) && string.IsNullOrEmpty(largeDescription)) {
                continue; 
            }
            translations.Add(new StaticHotelTranslationDto {
                LanguageIsoCode = language.GetIsoCode(),
                ShortDescription = shortDescription,
                LargeDescription = largeDescription,
                LocationDescription = string.IsNullOrEmpty(locationDescription) ? null : locationDescription
            });
        }

        return translations;
    }
}
