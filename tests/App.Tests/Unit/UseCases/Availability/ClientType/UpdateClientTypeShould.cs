namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.ClientType;

[TestFixture]
public class UpdateClientTypeShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateIntegrationClientType updateClientType;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateClientType = new UpdateIntegrationClientType(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_client_type() {
        //Given
        var anyMrcodi = 'A';
        var anyMrtext = "anyMrtext";
        var anyReseagen = new Restagen {
            Mrcodi = anyMrcodi,
            Mrtext = anyMrtext
        };

        //When
        await updateClientType.Execute(anyReseagen);

        //Then
        var expectedClientType = new Infrastructure.Dtos.BookingCenter.Availability.ClientType {
            Code = anyMrcodi.ToString(),
            Description = anyMrtext
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateClientType(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.ClientType>(c => IsEquivalent(c, expectedClientType)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
