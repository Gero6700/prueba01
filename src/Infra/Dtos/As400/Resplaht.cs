namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Resplaht {
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public required int Pthot { get; set; }
    public required string Pthab { get; set; } = string.Empty;
    public required int Ptfec { get; set; }
    public required int Ptcupo { get; set; }
    public required int Ptbloq { get; set; }
    public required int Ptreal { get; set; }
    public required int Ptgrup { get; set; }
    public required int Ptreag { get; set; }

    public int GetRoomQuantity => Ptcupo - Ptbloq ;
    public int GetOccupiedRooms => Ptreal + Ptgrup + Ptreag;
}
