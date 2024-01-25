namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.ClientType;

[TestFixture]
public class DeleteClientTypeShould{
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteClientType deleteClientType;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteClientType = new DeleteClientType();
    }

    [Test]
    public async Task delete_client_type() {
        //Given
        var anyMrcodi = 'A';
        
        //When
        await deleteClientType.Execute(anyMrcodi);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteClientType(Arg.Is<string>(c => IsEquivalent(c, anyMrcodi.ToString())));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
