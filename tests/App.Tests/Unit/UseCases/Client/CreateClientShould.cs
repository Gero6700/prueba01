
namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Client;

[TestFixture]
public class CreateClientShould {
    private CreateClient createClient = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createClient = new CreateClient();
    }

    [Test]
    public async Task create_client() {
        //Given
        const long anyIdUsuario = 123456789012;
        const string anyUsuario = "anyusuario";
        const string anyClave = "anyclave";
        const string anyNombreComercial = "nombreComercial";
        const char anyMrcodi = 'A';
       
        var anyClient = UsuregBuilder.AUsuregBuilder()
            .WithIdUsuario(anyIdUsuario)
            .WithUsuario(anyUsuario)
            .WithClave(anyClave)
            .WithNombreComercial(anyNombreComercial)
            .WithMrcodi(anyMrcodi)
            .Build();

        //When
        await createClient.Execute(anyClient);

        //Then
        var expectedClient = new Infrastructure.Dtos.BookingCenter.Client { 
            ClientTypeCode = anyMrcodi.ToString(),
            Code = anyIdUsuario.ToString(),
            CommercialName = anyNombreComercial,
            IntegrationPassword = anyClave,
            IntegrationUserName = anyUsuario
        }; 

        await availabilitySynchronizerApiClient.Received().CreateClient(expectedClient);

    }
}
