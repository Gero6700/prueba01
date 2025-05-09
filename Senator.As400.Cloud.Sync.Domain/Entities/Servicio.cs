using Senator.As400.Cloud.Sync.Domain.Abstractions.Core;

namespace Senator.As400.Cloud.Sync.Domain.Entities;

[Table("EST_servicios")]
public class Servicio(
    int id,
    int id_categoria,
    string? es_servicio,
    string? en_servicio,
    string? de_servicio,
    string? fr_servicio,
    string? pt_servicio
    ) : Entity(id) {
    [Column("es_servicio")]
    public string? EsServicio { get; set; } = es_servicio;
    [Column("en_servicio")]
    public string? EnServicio { get; set; } = en_servicio;
    [Column("de_servicio")]
    public string? DeServicio { get; set; } = de_servicio;
    [Column("fr_servicio")]
    public string? FrServicio { get; set; } = fr_servicio;
    [Column("pt_servicio")]
    public string? PtServicio { get; set; } = pt_servicio;
   
    [Column("id_categoria")]
    public int IdCategoria { get; set; } = id_categoria;

    public Servicio() :  this(0, 0, null, null, null, null, null) {
    } // Default constructor for EF Core
}
