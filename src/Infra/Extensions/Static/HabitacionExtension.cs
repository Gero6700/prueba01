
namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class HabitacionExtension {
    public static IEnumerable<StaticRoomDto> ToRoomDto(
        this IEnumerable<Habitacion> habitaciones, 
        IEnumerable<Imagen> imagenes, 
        IEnumerable<CamaTipo> camas,
        IEnumerable<HabitacionServicio> servicios) {

        if (!habitaciones.Any()) {
            return [];
        }

        return habitaciones.Select(habitacion => new StaticRoomDto {
            Code = habitacion.CodigoTipoHabitacion,
            RoomsNumber = habitacion.NumeroHabitaciones,
            Surface = habitacion.SuperficieAprox,
            RoomTranslations = GetTranslations(habitacion),
            RoomImages = !imagenes.Any() ? null :
                imagenes.Where(i => i.UidPadre.ToString() == habitacion.Uid).ToList().ToImageDto<StaticRoomImageDto>(),
            RoomPax = new StaticRoomPaxDto {
                MinWeight = habitacion.PesoMinimo,
                MaxWeight = habitacion.PesoMaximo,
                MinNumberAdults = habitacion.MinAdultos,
                MaxNumberAdults = habitacion.MaxAdultos,
                MinNumberChildren = habitacion.MinNinos,
                MaxNumberChildren = habitacion.MaxNinos,
                MinNumberBabies = habitacion.MinBebes,
                MaxNumberBabies = habitacion.MaxBebes
            },
            RoomBeds = !camas.Any() ? null :
                camas.Where(c => c.CodigoTipoHabitacion == habitacion.CodigoTipoHabitacion).ToList().ToRoomBedDto(),
            Equipments = null, //no tenemos datos
            Services = !servicios.Any() ? null :
                servicios.Where(s => s.IdHabitacion == habitacion.Id).Select(s => s.IdHabitacion.ToString()).ToList()
        });
    }
    private static List<StaticRoomTranslationDto> GetTranslations(Habitacion estHabitacion) {
        var translations = new List<StaticRoomTranslationDto>();

        var nameDescriptions = new Dictionary<Language, string> {
            { Language.Es, estHabitacion.EsNombreVerano },
            { Language.En, estHabitacion.EnNombreVerano },
            { Language.Fr, estHabitacion.FrNombreVerano },
            { Language.De, estHabitacion.DeNombreVerano },
            { Language.Pt, estHabitacion.PtNombreVerano }
        };

        var largeDescriptions = new Dictionary<Language, string> {
            { Language.Es, estHabitacion.EsDescripcion },
            { Language.En, estHabitacion.EnDescripcion },
            { Language.Fr, estHabitacion.FrDescripcion },
            { Language.De, estHabitacion.DeDescripcion },
            { Language.Pt, estHabitacion.PtDescripcion }
        };

        var shortDescriptions = new Dictionary<Language, string> {
            { Language.Es, estHabitacion.EsEntradilla },
            { Language.En, estHabitacion.EnEntradilla },
            { Language.Fr, estHabitacion.FrEntradilla },
            { Language.De, estHabitacion.DeEntradilla },
            { Language.Pt, estHabitacion.PtEntradilla }
        };

        foreach (var language in Enum.GetValues<Language>()) {
            if (!nameDescriptions.TryGetValue(language, out var name) ||
                !largeDescriptions.TryGetValue(language, out var largeDesc) ||
                !shortDescriptions.TryGetValue(language, out var shortDesc)) {
                continue;
            }
            if (string.IsNullOrEmpty(name)) {
                continue;
            }
            translations.Add(new StaticRoomTranslationDto {
                LanguageIsoCode = language.GetIsoCode(),
                Name = name,
                ShortDescription = string.IsNullOrEmpty(shortDesc) ? null : shortDesc,
                LargeDescription = string.IsNullOrEmpty(largeDesc) ? null : largeDesc
            });
        }

        return translations;
    }
}
