namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.ClientType;

[TestFixture]
public class DeleteClientTypeShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteClientType deleteClientType;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteClientType = new DeleteClientType(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_client_type() {
        //Given
        var anyMrcodi = 'A';
        var anyMrtext = "";
        var anyRestagen = new Restagen {
            Mrcodi = anyMrcodi,
            Mrtext = anyMrtext
        };

        //When
        await deleteClientType.Execute(anyRestagen);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteClientType(Arg.Is<string>(c => IsEquivalent(c, anyMrcodi.ToString())));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
