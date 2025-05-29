namespace Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;
public class HotelRepository(IUnitOfWork unitOfWork) : Repository<Hotel>(unitOfWork), IHotelRepository {

    public async Task<IEnumerable<int>?> GetAllHotelsIdsAsync() {
        //using var connection = Connection;
        var result = await Connection.QueryAsync<int>(
            "SELECT codigo_interno FROM EST_Hoteles WHERE tipo_establecimiento = 'h'",
            transaction: DbContext.Transaction);
        return [.. result];
    }

    public async Task<Hotel?> GetHotelAsync(int hotelId) {
        //using var connection = DbContext.Connection;
        var result = await Connection.QueryMultipleAsync(
            GetHotelQuery() + ";" + GetRegimenQuery() + ";" + 
            GetHabitacionQuery() + ";" + GetHabitacionCamaQuery() + ";" + GetHabitacionServicio() + ";" +
            GetPiscinaQuery() + ";" +
            GetSalonQuery() + ";" +
            GetServicioQuery() ,
            new { hotelId, hotelIdInLike = "%-"+ hotelId + "-%" }, 
            DbContext.Transaction);
        var hotel = result.Read<Hotel>().FirstOrDefault();
        if (hotel == null) {
            return null;
        }

        //hotel.Imagenes = [.. result.Read<Imagen>()];
        hotel.RegimenesCodes = [.. result.Read<string>()];
        hotel.Habitaciones = [.. result.Read<Habitacion>()];
        //hotel.HabitacionesImagenes = [.. result.Read<Imagen>()];
        hotel.HabitacionesCamas = [.. result.Read<CamaTipo>()];
        hotel.HabitacionesServicios = [.. result.Read<HabitacionServicio>()];
        hotel.Piscinas = [.. result.Read<Piscina>()];
        hotel.Salones = [.. result.Read<Salon>()];
       // hotel.SalonesImagenes = [.. result.Read<Imagen>()];
        hotel.ServiciosIds = [.. result.Read<int>()];

        //Se consultan las imagenes del hotel, las habitaciones y las piscinas segun los uid del resultado anterior
        var hotelUid = hotel.Uid;
        var roomUids = hotel.Habitaciones.Select(h => h.Uid).ToList();
        var piscinaUids = hotel.Piscinas.Select(p => p.Uid).ToList();
        var salonUids = hotel.Salones.Select(s => s.Uid).ToList();

        var imagesResult = await Connection.QueryMultipleAsync(
            GetHotelImagenQuery() + ";" + GetRoomImagenQuery() + ";" + GetPiscinaImageQuery() + ";" + GetSalonImageQuery(),
            new { hotelUid, roomUids, piscinaUids, salonUids },
            DbContext.Transaction);

        hotel.Imagenes = [.. imagesResult.Read<Imagen>()];
        hotel.HabitacionesImagenes = [.. imagesResult.Read<Imagen>()];
        hotel.PiscinasImagenes = [.. imagesResult.Read<Imagen>()];
        hotel.SalonesImagenes = [.. imagesResult.Read<Imagen>()];

        return hotel;
    }

    private static string GetHotelQuery() {
        return $@"
            SELECT 
                {GetHotelColumnsWithAlias()}                
            FROM EST_Hoteles h
            LEFT JOIN EST_marcas_comerciales m ON h.id_marca_comercial = m.id
            LEFT JOIN AUX_paises P ON h.codigo_pais = p.codigo_pais
            WHERE codigo_interno = @hotelId";                   
    }

    //private static string GetHotelImagenQuery() {
    //    return $@"
    //        SELECT 
    //            {GetImagesColumnsWithAliases()}                
    //        FROM EST_Imagenes2
    //        WHERE tabla_padre='EST_hoteles' AND uid_padre = @hotelUid";
    //}

    //private static string GetHabitacionImagenQuery() {
    //    return $@"
    //        SELECT 
    //            {GetImagesColumnsWithAliases()}                
    //        FROM EST_Imagenes2
    //        WHERE tabla_padre='EST_habitaciones' AND ";
    //}

    private static string GetHotelImagenQuery() {
        return $@"
            SELECT 
                {GetImagesColumnsWithAliases()}                
            FROM EST_Imagenes2
            WHERE visible = 1 AND tabla_padre='EST_Hoteles' AND uid_padre = @hotelUid";
    }

    private static string GetRoomImagenQuery() {
        return $@"
            SELECT 
                {GetImagesColumnsWithAliases()}                
            FROM EST_Imagenes2
            WHERE visible = 1 AND tabla_padre='EST_habitaciones' AND uid_padre IN @roomUids";
    }

    private static string GetHabitacionCamaQuery() {
        return $@"
            SELECT 
                {GetCamaTipoColumnsWithAlias()}                
            FROM EST_camas_tipos ct
            JOIN EST_R_habitaciones_camas hc ON ct.id = hc.id_cama
            JOIN EST_habitaciones h ON hc.id_habitacion = h.id AND h.visible = 1 AND h.codigo_interno_hotel = @hotelId";
    }

    private static string GetRegimenQuery() {
        return $@"
            SELECT 
                {GetRegimenColumnsWithAlias()}                
            FROM EST_regimenes
            WHERE id_hoteles like @hotelIDInLike";
    }

    private static string GetHabitacionQuery() {
        return $@"
            SELECT 
                {GetHabitacionColumnsWithAlias()}                
            FROM EST_habitaciones
            WHERE codigo_interno_hotel = @hotelId";
    }

    private static string GetPiscinaQuery() {
        return $@"
            SELECT 
                {GetPiscinaColumnsWithAlias()}                
            FROM EST_piscinas
            WHERE codigo_hotel = @hotelId";
    }

    private static string GetSalonQuery() {
        return $@"
            SELECT 
                {GetSalonColumnsWithAlias()}                
            FROM EST_salones
            WHERE codigo_hotel = @hotelId";
    }

    private static string GetSalonImageQuery() {
        return $@"
            SELECT 
                {GetImagesColumnsWithAliases()}                
            FROM EST_Imagenes2
            WHERE tabla_padre='EST_salones' AND uid_padre IN @salonUids";
    }

    private static string GetPiscinaImageQuery() {
        return $@"
            SELECT 
                {GetImagesColumnsWithAliases()}                
            FROM EST_Imagenes2
            WHERE tabla_padre='EST_piscinas' AND uid_padre IN @piscinaUids";
    }

    private static string GetServicioQuery() {
        return $@"
            SELECT 
                {GetServicioColumnsWithAlias()}                
            FROM EST_servicios s
            -- JOIN EST_servicios_categorias sc ON sc.id = s.id_categoria
            JOIN EST_R_servicios_hoteles hs ON hs.id_servicio = s.id AND hs.codigo_hotel = @hotelId";
    }

    //private static string GetHabitacionServicio() {
    //    return $@"
    //        SELECT 
    //            {GetServicioColumnsWithAlias()}, hs.id_habitacion AS IdHabitacion               
    //        FROM EST_servicios s
    //        -- JOIN EST_servicios_categorias sc ON sc.id = s.id_categoria
    //        JOIN EST_R_servicios_habitaciones hs ON hs.id_servicio = s.id
    //        JOIN EST_habitaciones h ON hs.id_habitacion = h.id and h.codigo_interno_hotel = @hotelId";
    //}

    private static string GetHabitacionServicio() {
        return $@"
            SELECT 
                hs.id_servicio as IdServicio, hs.id_habitacion AS IdHabitacion               
            FROM EST_R_servicios_habitaciones hs
            JOIN EST_habitaciones h ON hs.id_habitacion = h.id and h.codigo_interno_hotel = @hotelId";
    }

    private static string GetServicioColumnsWithAlias() {
        var columns = new List<string>
        {
            "s.id AS IdServicio"
            //"s.es_servicio AS EsServicio",
            //"s.en_servicio AS EnServicio",
            //"s.de_servicio AS DeServicio",
            //"s.fr_servicio AS FrServicio",
            //"s.pt_servicio AS PtServicio",
            //"sc.id AS IdCategoria",
            //"sc.es_nombre AS EsNombreCategoria",
            //"sc.en_nombre AS EnNombreCategoria",
            //"sc.fr_nombre AS FrNombreCategoria",
            //"sc.de_nombre AS DeNombreCategoria",
            //"sc.pt_nombre AS PtNombreCategoria",
            //"hs.es_detalles AS EsDetalle",
            //"hs.en_detalles AS EnDetalle",
            //"hs.fr_detalles AS FrDetalle",
            //"hs.de_detalles AS DeDetalle",
            //"hs.pt_detalles AS PtDetalle"
        };
        return string.Join(", ", columns);
    }

    private static string GetSalonColumnsWithAlias() {
        var columns = new List<string>
        {
            "uid as uid",
            "id AS Id",
            "es_nombre AS EsNombre",
            "superficie AS Superficie",
            "ancho AS Ancho",
            "largo AS Largo",
            "altura AS Altura",
            "aforo_banquete AS AforoBanquete",
            "aforo_cocktail AS AforoCocktail",
            "aforo_imperial AS AforoImperial",
            "aforo_en_u AS AforoU",
            "aforo_aula AS AforoAula",
            "es_descripcion AS EsDescripcion",
            "en_descripcion AS EnDescripcion",
            "fr_descripcion AS FrDescripcion",
            "de_descripcion AS DeDescripcion",
            "pt_descripcion AS PtDescripcion"
        };
        return string.Join(", ", columns);
    }

    private static string GetPiscinaColumnsWithAlias() {
        var columns = new List<string>
        {
            "id AS Id",
            "uid AS Uid",
            "cantidad AS Cantidad",
            "aforo AS Aforo",
            "superficie AS Superficie",
            "es_piscina AS EsPiscina",
            "en_piscina AS EnPiscina",
            "fr_piscina AS FrPiscina",
            "de_piscina AS DePiscina",
            "pt_piscina AS PtPiscina",
            "es_detalles AS EsDetalles",
            "en_detalles AS EnDetalles",
            "fr_detalles AS FrDetalles",
            "de_detalles AS DeDetalles",
            "pt_detalles AS PtDetalles"
        };
        return string.Join(", ", columns);
    }

    private static string GetCamaTipoColumnsWithAlias() {
        var columns = new List<string>
        {
            "h.codigo_tipo_habitacion AS CodigoTipoHabitacion",
            "ancho_cm AS AnchoCm",
            "alto_cm AS AltoCm",
            "es_nombre AS EsNombre",
            "en_nombre AS EnNombre",
            "fr_nombre AS FrNombre",
            "de_nombre AS DeNombre",
            "pt_nombre AS PtNombre"
        };
        return string.Join(", ", columns);
    }

    private static string GetHabitacionColumnsWithAlias() {
        var columns = new List<string>
        {
            "id AS Id",
            "uid AS Uid",
            "codigo_tipo_habitacion AS CodigoTipoHabitacion",
            "numero_habitaciones AS NumeroHabitaciones",
            "superficie_aprox AS SuperficieAprox",
            "peso_minimo AS PesoMinimo",
            "peso_maximo AS PesoMaximo",
            "min_bebes AS MinBebes",
            "max_bebes AS MaxBebes",
            "min_ninos AS MinNinos",
            "max_ninos AS MaxNinos",
            "min_adultos AS MinAdultos",
            "max_adultos AS MaxAdultos",
            "es_nombre_verano AS EsNombreVerano",
            "en_nombre_verano AS EnNombreVerano",
            "fr_nombre_verano AS FrNombreVerano",
            "de_nombre_verano AS DeNombreVerano",
            "pt_nombre_verano AS PtNombreVerano",
            "es_descripcion AS EsDescripcion",
            "en_descripcion AS EnDescripcion",
            "fr_descripcion AS FrDescripcion",
            "de_descripcion AS DeDescripcion",
            "pt_descripcion AS PtDescripcion",
            "es_entradilla AS EsEntradilla",
            "en_entradilla AS EnEntradilla",
            "fr_entradilla AS FrEntradilla",
            "de_entradilla AS DeEntradilla",
            "pt_entradilla AS PtEntradilla"

        };
        return string.Join(", ", columns);
    }

    private static string GetRegimenColumnsWithAlias() {
        var columns = new List<string>
        {
            "regimen AS Codigo"
    };
        return string.Join(", ", columns);
    }

    private static string GetHotelColumnsWithAlias() {
        var columns = new List<string>
        {
            "uid AS Uid",
        "codigo_interno AS CodigoInterno",
        "nombre_hotel AS NombreHotel",
        "cerrado_desde AS CerradoDesde",
        "cerrado_hasta AS CerradoHasta",
        "codigo_categoria AS CodigoCategoria",
        "m.nombre AS NombreMarcaComercial",
        "codigo_tipo_hotel AS CodigoTipoHotel",
        "director AS Director",
        "numero_habitaciones AS NumeroHabitaciones",
        "numero_plantas AS NumeroPlantas",
        "ano_construccion AS AnioConstruccion",
        "es_pais AS EsPais",
        "p.siglas AS CodigoPaisIso",
        "nombre_provincia AS NombreProvincia",
        "codigo_provincia AS CodigoProvincia",
        "nombre_localidad AS NombreLocalidad",
        "codigo_localidad AS CodigoLocalidad",
        "domicilio AS Domicilio",
        "h.codigo_postal AS CodigoPostal",
        "gmaps_latitud AS GmapsLatitud",
        "gmaps_longitud AS GmapsLongitud",
        "telefono AS Telefono",
        "fax AS Fax",
        "email AS Email",
        "url_web AS Web",
        "edad_min_nino AS EdadMinNino",
        "edad_max_nino AS EdadMaxNino",
        "edad_min_bebe AS EdadMinBebe",
        "edad_max_bebe AS EdadMaxBebe",
        "es_entradilla AS EsEntradilla",
        "es_descripcion AS EsDescripcion",
        "es_situacion AS EsSituacion",
        "en_entradilla AS EnEntradilla",
        "en_descripcion AS EnDescripcion",
        "en_situacion AS EnSituacion",
        "fr_entradilla AS FrEntradilla",
        "fr_descripcion AS FrDescripcion",
        "fr_situacion AS FrSituacion",
        "de_entradilla AS DeEntradilla",
        "de_descripcion AS DeDescripcion",
        "de_situacion AS DeSituacion",
        "pt_entradilla AS PtEntradilla",
        "pt_descripcion AS PtDescripcion",
        "pt_situacion AS PtSituacion"
    };

        return string.Join(", ", columns);
    }

    private static string GetImagesColumnsWithAliases() {
        var columns = new List<string>
        {
            "uid_padre AS UidPadre",
            "id_salon AS IdSalon",
            "prioridad AS Prioridad",
            "id AS Url",
            "es_titulo AS EsTitulo",
            "en_titulo AS EnTitulo",
            "fr_titulo AS FrTitulo",
            "de_titulo AS DeTitulo",
            "pt_titulo AS PtTitulo",
            "es_descripcion AS EsDescripcion",
            "en_descripcion AS EnDescripcion",
            "fr_descripcion AS FrDescripcion",
            "de_descripcion AS DeDescripcion",
            "pt_descripcion AS PtDescripcion"
        };

        return string.Join(", ", columns);
    }
}
