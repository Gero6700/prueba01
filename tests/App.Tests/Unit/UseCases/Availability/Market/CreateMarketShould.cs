namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Market;

[TestFixture]
public class CreateMarketShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMarket createMarket;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMarket = new CreateMarket(availabilitySynchronizerApiClient);
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
        var expectedMarket = new Infrastructure.Dtos.BookingCenter.Availability.Market {
            Code = anyCod,
            Description = anyNom
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateMarket(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Market>(c => IsEquivalent(c, expectedMarket)));
    }

    [Test]
    public async Task do_not_create_market_when_code_is_empty() {
        //Given
        const string anyCod = "";
        const string anyNom = "anyNom";
        var anyMerca = new Merca {
            Cod = anyCod,
            Nom = anyNom
        };

        //When
        Func<Task> function = async () => await createMarket.Execute(anyMerca);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect market code");
    }


    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

