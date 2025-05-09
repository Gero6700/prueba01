using Senator.As400.Cloud.Sync.Domain.Abstractions.Core;

namespace Senator.As400.Cloud.Sync.Domain.Entities;

[Table("EST_servicios_categorias")]
public class ServicioCategoria(
    int id,
    string? es_nombre,
    string? en_nombre,
    string? fr_nombre,
    string? de_nombre,
    string? pt_nombre,
    int prioridad
    ) : Entity(id) {
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
    public ServicioCategoria() : this(0, null, null, null, null, null,0) {
    } // Default constructor for EF Core
}
