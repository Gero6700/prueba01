using Senator.As400.Cloud.Sync.Application.UseCases.Client;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.ClientType;

[TestFixture]
public class CreateClientTypeShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateClientType createClientType;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createClientType = new CreateClientType(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_client_type() {
        //Given
        var anyMrcodi = 'A';
        var anyMrtext = "anyMrtext";
        var anyClientType = new Restagen {
            Mrcodi = anyMrcodi,
            Mrtext = anyMrtext
        };

        //When
        await createClientType.Execute(anyClientType);

        //Then
        var expectedClientType = new Infrastructure.Dtos.BookingCenter.ClientType {
            Code = anyMrcodi.ToString(),
            Description = anyMrtext
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateClientType(Arg.Is<Infrastructure.Dtos.BookingCenter.ClientType>(c => IsEquivalent(c, expectedClientType)));

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
