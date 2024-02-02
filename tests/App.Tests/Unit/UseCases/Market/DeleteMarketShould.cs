namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Market;

[TestFixture]
public class DeleteMarketShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteMarket deleteMarket;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteMarket = new DeleteMarket();
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
        var expectedMarket = new Infrastructure.Dtos.BookingCenter.Market {
            Code = anyCod,
            Description = anyNom
        };

        await availabilitySynchronizerApiClient.Received()
            .DeleteMarket(Arg.Is<Infrastructure.Dtos.BookingCenter.Market>(c => IsEquivalent(c, expectedMarket)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
