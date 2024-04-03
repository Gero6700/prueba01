namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.ClientType;

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
        var anyRestagen = new Restagen {
            Mrcodi = anyMrcodi,
            Mrtext = anyMrtext
        };

        //When
        await createClientType.Execute(anyRestagen);

        //Then
        var expectedClientType = new Infrastructure.Dtos.BookingCenter.Availability.ClientType {
            Code = anyMrcodi.ToString(),
            Description = anyMrtext
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateClientType(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.ClientType>(c => IsEquivalent(c, expectedClientType)));

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
