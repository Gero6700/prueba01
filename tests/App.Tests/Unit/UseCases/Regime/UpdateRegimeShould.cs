namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Regime;

[TestFixture]
public class UpdateRegimeShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateRegime updateRegime;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateRegime = new UpdateRegime(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_regime() {
        //Given
        const string anyMrhab = "anyCode";
        const int anyRoorde = 1;

        var restregi = new Restregi {
            Mrhab = anyMrhab,
            Roorde = anyRoorde
        };

        //When
        await updateRegime.Execute(restregi);  
        
        //Then
        var expectedRegime = new Infrastructure.Dtos.BookingCenter.Regime {
            Code = anyMrhab,
            Order = anyRoorde
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateRegime(Arg.Is<Infrastructure.Dtos.BookingCenter.Regime>(x => IsEquivalent(x, expectedRegime)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
