namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Regime;

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
        var expectedRegime = new Infrastructure.Dtos.BookingCenter.Availability.Regime {
            Code = anyMrhab,
            Order = anyRoorde
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateRegime(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Regime>(x => IsEquivalent(x, expectedRegime)));
    }

    [Test]
    public async Task do_not_update_regime_when_mrhab_is_empty() {
        //Given
        const string anyMrhab = "";
        const int anyRoorde = 1;

        var anyRestregi = new Restregi {
            Mrhab = anyMrhab,
            Roorde = anyRoorde
        };

        //When
        Func<Task> function = async () => await updateRegime.Execute(anyRestregi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect regime code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
