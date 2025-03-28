using Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;
using Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

namespace Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;
public class StaticHotelRepository(IUnitOfWork unitOfWork) : Repository<Hotel>(unitOfWork), IStaticHotelRepository {
    public async Task<Hotel?> GetHotelAsync(int hotelId) {
        var result = await Connection.QueryMultipleAsync(GetHotelQuery() + ";" + GetImagesQuery(), 
            new { hotelId }, Transaction);
        var hotel = result.Read<Hotel>().FirstOrDefault();
        if (hotel == null) {
            return null;
        }
        var images = result.Read<Imagen>().ToList();

        return hotel with { Imagenes = images };
    }

    private static string GetHotelQuery() {
        return $@"
            SELECT 
                {GetHotelColumnsWithAlias()}                
            FROM EST_Hoteles
            WHERE codigo_interno = @hotelId";                   
    }

    private static string GetImagesQuery() {
        return $@"
            SELECT 
                {GetImagesColumnsWithAliases()}                
            FROM EST_Hoteles_Imagenes
            WHERE codigo_interno_hotel = @hotelId AND tabla_padre='EST_hoteles'";
    }

    private static string GetHotelColumnsWithAlias() {
        var columns = new List<string>
        {
        "codigo_interno AS CodigoInterno",
        "nombre_hotel AS NombreHotel",
        "cerrado_desde AS CerradoDesde",
        "cerrado_hasta AS CerradoHasta",
        "codigo_categoria AS CodigoCategoria",
        "nombre_marca_comercial AS NombreMarcaComercial",
        "codigo_tipo_hotel AS CodigoTipoHotel",
        "director AS Director",
        "numero_habitaciones AS NumeroHabitaciones",
        "numero_plantas AS NumeroPlantas",
        "anio_construccion AS AnioConstruccion",
        "es_pais AS EsPais",
        "codigo_pais_iso AS CodigoPaisIso",
        "nombre_provincia AS NombreProvincia",
        "codigo_provincia_iso AS CodigoProvinciaIso",
        "nombre_localidad AS NombreLocalidad",
        "codigo_localidad AS CodigoLocalidad",
        "domicilio AS Domicilio",
        "codigo_postal AS CodigoPostal",
        "gmaps_latitud AS GmapsLatitud",
        "gmaps_longitud AS GmapsLongitud",
        "telefono AS Telefono",
        "fax AS Fax",
        "email AS Email",
        "web AS Web",
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
        "prioridad AS Prioridad",
        "url AS Url",
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
