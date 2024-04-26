using System.Transactions;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstHotelExtension {
    public static Dtos.BookingCenter.Static.Hotel ToHotel(this EstHotel estHotel) {
        return new Dtos.BookingCenter.Static.Hotel {
            Code = estHotel.CodigoInterno.ToString(),
            Name = estHotel.NombreHotel,
            OpeningDate = estHotel.CerradoHasta?.AddDays(1),
            ClosingDate = estHotel.CerradoDesde,
            Category = estHotel.CodigoCategoria,
            CodeType = estHotel.NombreMarcaComercial,
            Type = estHotel.CodigoTipoHotel,
            Director = estHotel.Director,
            NumberOfRooms = estHotel.NumeroHabitaciones,
            Floors = estHotel.NumeroPlantas,
            BuildYear = estHotel.AnioConstruccion,
            Country = estHotel.EsPais,
            CountryCode = estHotel.CodigoPaisIso,
            StateProvince = estHotel.NombreProvincia,
            StateProvinceCode = estHotel.CodigoProvinciaIso,
            City = estHotel.NombreLocalidad,
            CityCode = estHotel.CodigoLocalidad,
            StreetAddress = estHotel.Domicilio,
            PostalCode = estHotel.CodigoPostal,
            Latitude = estHotel.GmapsLatitud,
            Longitude = estHotel.GmapsLongitud,
            Phone = estHotel.Telefono,
            Fax = estHotel.Fax,
            Email = estHotel.Email,
            Web = estHotel.Web,
            ChildMinAge = estHotel.EdadMinNino,
            ChildMaxAge = estHotel.EdadMaxNino,
            TeenMinAge = estHotel.EdadMaxNino + 0.01m,
            TeenMaxAge = 17.99m,
            InfantMinAge = estHotel.EdadMinBebe,
            InfantMaxAge = estHotel.EdadMaxBebe,
            Languages = [],
            Descriptions = GetDescriptions(estHotel),
            Images = estHotel.Imagenes.Select(imagen => new Image {
                Order = imagen.Prioridad,
                Url = imagen.Url,
                Translations = GetImageTranslations(imagen)
            }).ToList(),
            Rooms = estHotel.Habitaciones.Select(habitacion => new Dtos.BookingCenter.Static.Room
            {
                Code = habitacion.CodigoTipoHabitacion,
                Quantity = habitacion.NumeroHabitaciones,
                Surface = habitacion.SuperficieAprox,
                MinWeight = habitacion.PesoMinimo,
                MaxWeight = habitacion.PesoMaximo,
                MinInfants = habitacion.MinBebes,
                MaxInfants = habitacion.MaxBebes,
                MinChildren = habitacion.MinNinos,
                MaxChildren = habitacion.MaxNinos,
                MinTeens = null,
                MaxTeens = null,
                MinAdults = habitacion.MinAdultos,
                MaxAdults = habitacion.MaxAdultos,
                Equipments = [],
                Beds = habitacion.Camas.Select(cama => new Bed {
                    Width = cama.AnchoCm,
                    Length = cama.AltoCm,
                    Translations = GetBedTranslations(cama)
                }).ToList(),
                Images = habitacion.Imagenes.Select(imagen => new Image {
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = GetImageTranslations(imagen)
                }).ToList(),
                Translations = GetRoomTranslations(habitacion)                
            }).ToList(),
            SwimmingPools = estHotel.Piscinas.Select(piscina => new SwimmingPool {
                Code = piscina.Id.ToString(),
                NumberOfPools = piscina.Cantidad,
                Surface = piscina.Superficie,
                Capacity = piscina.Aforo,
                Translations = GetSwimmingPoolTranslations(piscina),
                Images = piscina.Imagenes.Select(imagen => new Image {
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = GetImageTranslations(imagen)
                }).ToList()
            }).ToList(),
            Salons = estHotel.Salones.Select(salon => new Salon {
                Code = salon.Id.ToString(),
                Name = salon.EsNombre,
                Surface = salon.Superficie,
                Width = salon.Ancho,
                Length = salon.Largo,
                Height = salon.Altura,
                FeastCapacity = salon.AforoBanquete,
                CocktailCapacity = salon.AforoCocktail,
                ImperialCapacity = salon.AforoImperial,
                UCapacity = salon.AforoU,
                ClassroomCapacity = salon.AforoAula,
                Images = salon.Imagenes.Select(imagen => new Image {
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = GetImageTranslations(imagen)
                }).ToList(),
                Translations = GetSalonTranslations(salon)
            }).ToList(),
            Services = estHotel.IdServicios.Select(servicio => servicio.ToString()).ToList(),
            Taxes = estHotel.IdReszoims
        };
    }

    private static List<Description> GetDescriptions(EstHotel estHotel) {
        var descriptions = new List<Description>();

        var languages = new Dictionary<string, (string ShortDescription, string LargeDescription, string LocationDescription)>
        {
            { Language.Es.GetIsoCode(), (estHotel.EsEntradilla, estHotel.EsDescripcion, estHotel.EsSituacion) },
            { Language.En.GetIsoCode(), (estHotel.EnEntradilla, estHotel.EnDescripcion, estHotel.EnSituacion) },
            { Language.Fr.GetIsoCode(), (estHotel.FrEntradilla, estHotel.FrDescripcion, estHotel.FrSituacion) },
            { Language.De.GetIsoCode(), (estHotel.DeEntradilla, estHotel.DeDescripcion, estHotel.DeSituacion) },
            { Language.Pt.GetIsoCode(), (estHotel.PtEntradilla, estHotel.PtDescripcion, estHotel.PtSituacion) }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value.ShortDescription)) {
                descriptions.Add(new Description {
                    ShortDescription = language.Value.ShortDescription,
                    LargeDescription = language.Value.LargeDescription,
                    LocationDescription = language.Value.LocationDescription,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return descriptions;
    }

    private static List<ImageTranslation> GetImageTranslations(EstImagen imagen) {
        var translations = new List<ImageTranslation>();

        var languages = new Dictionary<string, (string Title, string Description)> {
            { Language.Es.GetIsoCode(), (imagen.EsTitulo, imagen.EsDescripcion) },
            { Language.En.GetIsoCode(), (imagen.EnTitulo, imagen.EnDescripcion) },
            { Language.Fr.GetIsoCode(), (imagen.FrTitulo, imagen.FrDescripcion) },
            { Language.De.GetIsoCode(), (imagen.DeTitulo, imagen.DeDescripcion) },
            { Language.Pt.GetIsoCode(), (imagen.PtTitulo, imagen.PtDescripcion) }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value.Title)) {
                translations.Add(new ImageTranslation {
                    Title = language.Value.Title,
                    Description = language.Value.Description,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }

    private static List<Translation> GetBedTranslations(EstCamaTipo cama) {
        var translations = new List<Translation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), cama.EsNombre },
            { Language.En.GetIsoCode(), cama.EnNombre },
            { Language.Fr.GetIsoCode(), cama.FrNombre },
            { Language.De.GetIsoCode(), cama.DeNombre },
            { Language.Pt.GetIsoCode(), cama.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new Translation {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }

    private static List<RoomTranslation> GetRoomTranslations(EstHabitacion habitacion) {
        var translations = new List<RoomTranslation>();

        var languages = new Dictionary<string, (string Name, string Description, string ShortDescription)> {
            { Language.Es.GetIsoCode(), (habitacion.EsNombreVerano, habitacion.EsDescripcion, habitacion.EsEntradilla) },
            { Language.En.GetIsoCode(), (habitacion.EnNombreVerano, habitacion.EnDescripcion, habitacion.EnEntradilla) },
            { Language.Fr.GetIsoCode(), (habitacion.FrNombreVerano, habitacion.FrDescripcion, habitacion.FrEntradilla) },
            { Language.De.GetIsoCode(), (habitacion.DeNombreVerano, habitacion.DeDescripcion, habitacion.DeEntradilla) },
            { Language.Pt.GetIsoCode(), (habitacion.PtNombreVerano, habitacion.PtDescripcion, habitacion.PtEntradilla) }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value.Name)) {
                translations.Add(new RoomTranslation {
                    Name = language.Value.Name,
                    Description = language.Value.Description,
                    ShortDescription = language.Value.ShortDescription,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }

    private static List<Translation> GetSwimmingPoolTranslations(EstPiscina piscina) {
        var translations = new List<Translation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), piscina.EsPiscina },
            { Language.En.GetIsoCode(), piscina.EnPiscina },
            { Language.Fr.GetIsoCode(), piscina.FrPiscina },
            { Language.De.GetIsoCode(), piscina.DePiscina },
            { Language.Pt.GetIsoCode(), piscina.PtPiscina }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new Translation {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }

    private static List<Translation> GetSalonTranslations(EstSalon salon) {
        var translations = new List<Translation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), salon.EsDescripcion },
            { Language.En.GetIsoCode(), salon.EnDescripcion },
            { Language.Fr.GetIsoCode(), salon.FrDescripcion },
            { Language.De.GetIsoCode(), salon.DeDescripcion },
            { Language.Pt.GetIsoCode(), salon.PtDescripcion }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new Translation {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }
}
