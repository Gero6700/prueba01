namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Client;

[TestFixture]
public class CreateClientShould {
    private CreateClient createClient = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createClient = new CreateClient(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_client() {
        //Given
        const long anyIdUsuario = 123456789012;
        const string anyUsuario = "anyUsuario";
        const string anyClave = "anyClave";
        const string anyNombreComercial = "anyNombreComercial";
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
            Code = anyIdUsuario.ToString(),
            CommercialName = anyNombreComercial,
            IntegrationUserName = anyUsuario,
            IntegrationPassword = anyClave,
            ClientTypeCode = anyMrcodi.ToString()      
        }; 

        await availabilitySynchronizerApiClient.Received()
            .CreateClient(Arg.Is<Infrastructure.Dtos.BookingCenter.Client>(c => IsEquivalent(c, expectedClient)));

    }
        private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
