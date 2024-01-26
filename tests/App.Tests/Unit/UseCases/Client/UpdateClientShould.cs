using Senator.As400.Cloud.Sync.Application.UseCases.Client;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Client;

[TestFixture]
public class UpdateClientShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateClient updateClient = null!;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateClient = new UpdateClient(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_client() {
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
        await updateClient.Execute(anyUsureg);

        //Then
        var expectedClient = new Infrastructure.Dtos.BookingCenter.Client {
            Code = anyIdUsuario.ToString(),
            CommercialName = anyNombreComercial,
            IntegrationUserName = anyUsuario,
            IntegrationPassword = anyClave,
            ClientTypeCode = anyAgGroup.ToString()      
        }; 

        await availabilitySynchronizerApiClient.Received()
            .UpdateClient(Arg.Is<Infrastructure.Dtos.BookingCenter.Client>(c => IsEquivalent(c, expectedClient)));

    }

    [Test]
    public async Task do_not_update_client_when_idusuario_is_zero() {
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
        Func<Task> function = async () => await updateClient.Execute(anyUsureg);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect user code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
