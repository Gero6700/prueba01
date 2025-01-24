namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Client;

[TestFixture]
public class CreateClientShould {
    private CreateIntegration createClient = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createClient = new CreateIntegration(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_client() {
        //Given
        const long anyIdUsuario = 123456789012;
        const string anyUsuario = "anyUsuario";
        const string anyClave = "anyClave";
        const string anyNombreComercial = "anyNombreComercial";
        const char anyAgGroup = 'A';

        var anyUsureg = UsuregBuilder.AnUsuregBuilder()
            .WithIdUsuario(anyIdUsuario)
            .WithUsuario(anyUsuario)
            .WithClave(anyClave)
            .WithNombreComercial(anyNombreComercial)
            .WithAgGroup(anyAgGroup)
            .Build();

        //When
        await createClient.Execute(anyUsureg);

        //Then
        var expectedClient = new Infrastructure.Dtos.BookingCenter.Availability.Client {
            Code = anyIdUsuario.ToString(),
            CommercialName = anyNombreComercial,
            IntegrationUserName = anyUsuario,
            IntegrationPassword = anyClave,
            ClientTypeCode = anyAgGroup.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateClient(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Client>(c => IsEquivalent(c, expectedClient)));

    }

    [Test]
    public async Task do_not_create_client_when_idusuario_is_zero() {
        //Given
        const long anyIdUsuario = 0;
        const string anyUsuario = "anyUsuario";
        const string anyClave = "anyClave";
        const string anyNombreComercial = "anyNombreComercial";
        const char anyAgGroup = 'A';

        var anyUsureg = UsuregBuilder.AnUsuregBuilder()
            .WithIdUsuario(anyIdUsuario)
            .WithUsuario(anyUsuario)
            .WithClave(anyClave)
            .WithNombreComercial(anyNombreComercial)
            .WithAgGroup(anyAgGroup)
            .Build();

        //When
        Func<Task> function = async () => await createClient.Execute(anyUsureg);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect user code");
    }
    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
