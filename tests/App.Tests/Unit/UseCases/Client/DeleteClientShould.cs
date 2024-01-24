namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Client;

[TestFixture]
public class DeleteClientShould {
    private DeleteClient deleteClient = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp] 
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteClient = new DeleteClient();
    }

    [Test]
    public async Task delete_client() {
        //Given
        const long anyIdUsuario = 123456789012;

        //When
        await deleteClient.Execute(anyIdUsuario);

        //Then
        var expectedCode = anyIdUsuario.ToString();
        await availabilitySynchronizerApiClient.Received()
            .DeleteClient(Arg.Is<string>(c => IsEquivalent(c, expectedCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
