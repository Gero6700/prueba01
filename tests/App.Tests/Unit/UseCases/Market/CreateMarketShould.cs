namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Market;

[TestFixture]
public class CreateMarketShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMarket createMarket;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMarket = new CreateMarket();
    }

    [Test]
    public async Task create_market() {
        //Given
        const string anyCod = "COD";
        const string anyNom = "anyNom";
        var anyMerca = new Merca {
            Cod = anyCod,
            Nom = anyNom
        };

        //When
        await createMarket.Execute(anyMerca);

        //Then
        var expectedMarket = new Infrastructure.Dtos.BookingCenter.Market {
            Code = anyCod,
            Description = anyNom
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateMarket(Arg.Is<Infrastructure.Dtos.BookingCenter.Market>(c => IsEquivalent(c, expectedMarket)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

