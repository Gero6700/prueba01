namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Regime;

[TestFixture]
public class PushStaticRegimesShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticRegimes pushStaticRegimes;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticRegimes = new PushStaticRegimes(staticSynchronizerApiClient);
    }

    [Test]
    public async Task push_static_regimes() {
        //Given
        var givenEstRegimenes = new List<EstRegimen>() {
            EstRegimenBuilder.AnEstRegimenBuilder().Build(),
            EstRegimenBuilder.AnEstRegimenBuilder().Build(),
            EstRegimenBuilder.AnEstRegimenBuilder().Build(),
            EstRegimenBuilder.AnEstRegimenBuilder().Build(),
            EstRegimenBuilder.AnEstRegimenBuilder().Build()
        };

        //when
        await pushStaticRegimes.Execute(givenEstRegimenes);

        //Then
        var expectedRegimes = givenEstRegimenes.Select(x => new Infrastructure.Dtos.BookingCenter.Static.Regime {
            Code = x.Regimen,
            Translations = [
                new Translation() {
                    Name = x.EsNombre,
                    LanguageIsoCode = Language.Es.GetIsoCode()
                },
                new Translation() {
                    Name = x.EnNombre,
                    LanguageIsoCode = Language.En.GetIsoCode()
                },
                new Translation() {
                    Name = x.DeNombre,
                    LanguageIsoCode = Language.De.GetIsoCode()
                },
                new Translation() {
                    Name = x.FrNombre,
                    LanguageIsoCode = Language.Fr.GetIsoCode()
                },
                new Translation() {
                    Name = x.PtNombre,
                    LanguageIsoCode = Language.Pt.GetIsoCode()
                }
                ]
        }).ToList();

        await staticSynchronizerApiClient.Received()
            .PushRegimes(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.Regime>>(x => IsEquivalent(x, expectedRegimes)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
