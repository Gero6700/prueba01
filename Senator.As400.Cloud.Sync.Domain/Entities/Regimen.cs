namespace Senator.As400.Cloud.Sync.Domain.Entities;

[Table("EST_regimenes")]
public class Regimen(
    int id,
    int id_hotel,
    string? id_hoteles,
    string regimen,
    string? es_nombre,
    string? en_nombre,
    string? fr_nombre,
    string? de_nombre,
    string? pt_nombre,
    string? es_entradilla,
    string? en_entradilla,
    string? fr_entradilla,
    string? de_entradilla,
    string? pt_entradilla,
    string? es_descripcion,
    string? en_descripcion,
    string? fr_descripcion,
    string? de_descripcion,
    string? pt_descripcion,
    bool visible,
    DateTime? fecha_actualizacion,
    int nro_orden
    ) : Entity(id) {
    [Column("regimen")]
    public string Codigo { get; set; } = regimen;
    [Column("es_nombre")]
    public string? EsNombre { get; set; } = es_nombre;
    [Column("en_nombre")]
    public string? EnNombre { get; set; } = en_nombre;
    [Column("fr_nombre")]
    public string? FrNombre { get; set; } = fr_nombre;
    [Column("de_nombre")]
    public string? DeNombre { get; set; } = de_nombre;
    [Column("pt_nombre")]
    public string? PtNombre { get; set; } = pt_nombre;

    public Regimen() : this(0, 0, null, string.Empty, null, null, null, null, null, null, null,
        null, null, null, null, null, null, null, null, false, DateTime.Now, 0) {
    } // Default constructor for EF Core
}
