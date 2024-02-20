namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Regime;

[TestFixture]
public class CreateRegimeShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateRegime createRegime;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createRegime = new CreateRegime();
    }

    [Test]
    public async Task create_regimen() {
        //Given
        const string anyMrhab = "anyCode";
        const int anyRoorde = 1;

        var restregi = new Restregi {
            Mrhab = anyMrhab,
            Roorde = anyRoorde
        };

        //When
        await createRegime.Execute(restregi);  
        
        //Then
        var expectedRegime = new Infrastructure.Dtos.BookingCenter.Regime {
            Code = anyMrhab,
            Order = anyRoorde
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateRegime(Arg.Is<Infrastructure.Dtos.BookingCenter.Regime>(x => IsEquivalent(x, expectedRegime)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
