namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Market;

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
        var expectedMarket = new Infrastructure.Dtos.BookingCenter.Availability.Market {
            Code = anyCod,
            Description = anyNom
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateMarket(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Market>(c => IsEquivalent(c, expectedMarket)));
    }

    [Test]
    public async Task do_not_update_market_when_code_is_empty() {
        //Given
        const string anyCod = "";
        const string anyNom = "anyNom";
        var anyMerca = new Merca {
            Cod = anyCod,
            Nom = anyNom
        };

        //When
        Func<Task> function = async () => await updateMarket.Execute(anyMerca);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect market code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
