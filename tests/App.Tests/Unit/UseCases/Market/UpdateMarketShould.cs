namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Market;

[TestFixture]
public class UpdateMarketShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateMarket updateMarket;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateMarket = new UpdateMarket(availabilitySynchronizerApiClient);
    }
    [Test]
    public async Task update_market() {
        //Given
        const string anyCod = "COD";
        const string anyNom = "anyNom";
        var anyMerca = new Merca {
            Cod = anyCod,
            Nom = anyNom
        };

        //When
        await updateMarket.Execute(anyMerca);

        //Then
        var expectedMarket = new Infrastructure.Dtos.BookingCenter.Market {
            Code = anyCod,
            Description = anyNom
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateMarket(Arg.Is<Infrastructure.Dtos.BookingCenter.Market>(c => IsEquivalent(c, expectedMarket)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
