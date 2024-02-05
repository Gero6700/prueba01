using System;

namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Resplaht {
    public int Pthot { get; set; }
    public string Pthab { get; set; } = string.Empty;
    public int Ptfec { get; set; }
    public int Ptcupo { get; set; }
    public int Ptbloq { get; set; }
    public int Ptreal { get; set; }
    public int Ptgrup { get; set; }
    public int Ptreag { get; set; }

    public int GetRoomQuantity => Ptcupo - Ptbloq - Ptreal - Ptgrup - Ptreag;

}
