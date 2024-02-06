namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Market;

[TestFixture]
public class DeleteMarketShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteMarket deleteMarket;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteMarket = new DeleteMarket(availabilitySynchronizerApiClient);
    }

    [Test]  
    public async Task delete_market() {
        //Given
        const string anyCod = "COD";
        const string anyNom = "";
        var anyMerca = new Merca {
            Cod = anyCod,
            Nom = anyNom
        };

        //When
        await deleteMarket.Execute(anyMerca);

        //Then
        var expectedMarketCode = anyCod;

        await availabilitySynchronizerApiClient.Received()
            .DeleteMarket(Arg.Is<string>(c => IsEquivalent(c, expectedMarketCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
