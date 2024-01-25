namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.ClientType;

[TestFixture]
public class UpdateClientShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateClientType updateClientType;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateClientType = new UpdateClientType();
    }

    [Test]
    public async Task update_client_type() {
       //Given
       var anyMrcodi = 'A';
       var anyMrtext = "anyMrtext";
       var anyClientType = new Restagen {
           Mrcodi = anyMrcodi,
           Mrtext = anyMrtext
       };
       
        //When
        await updateClientType.Execute(anyClientType);

        //Then
        var expectedClientType = new Infrastructure.Dtos.BookingCenter.ClientType {
            Code = anyMrcodi.ToString(),
            Description = anyMrtext
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateClientType(Arg.Is<Infrastructure.Dtos.BookingCenter.ClientType>(c => IsEquivalent(c, expectedClientType)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
