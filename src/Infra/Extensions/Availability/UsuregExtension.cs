using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class UsuregExtension {
    public static IntegrationDto ToClient(this Usureg usureg) {
        return new IntegrationDto {
            Code = usureg.IdUsuario.ToString(),
            CommercialName = usureg.NombreComercial,
            Username = usureg.Usuario,
            Password = usureg.Clave,
            IntegrationClientTypeCode = usureg.AgGroup.ToString(),
            Active = true
        };
    }
}
