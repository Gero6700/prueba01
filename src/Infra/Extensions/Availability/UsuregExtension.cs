using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class UsuregExtension {
    public static Client ToClient(this Usureg usureg) {
        return new Client {
            Code = usureg.IdUsuario.ToString(),
            CommercialName = usureg.NombreComercial,
            IntegrationUserName = usureg.Usuario,
            IntegrationPassword = usureg.Clave,
            ClientTypeCode = usureg.AgGroup.ToString()
        };
    }
}
