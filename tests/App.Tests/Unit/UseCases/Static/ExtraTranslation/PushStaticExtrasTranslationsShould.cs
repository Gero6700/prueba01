using System.Formats.Asn1;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.ExtraTranslation;

[TestFixture]
public class PushStaticExtrasTranslationsShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticExtrasTranslations pushStaticExtrasTranslations;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticExtrasTranslations = new PushStaticExtrasTranslations();
    }

    [Test]
    public async Task push_static_extras_translations() {
        //Given
        var givenDesextrs = new List<Desextr>() {
            DesextrBuilder.ADesextrBuilder().WithIdioIsoCode(Language.Es.GetIsoCode()).Build(),
            DesextrBuilder.ADesextrBuilder().WithIdioIsoCode(Language.En.GetIsoCode()).Build(),
            DesextrBuilder.ADesextrBuilder().WithIdioIsoCode(Language.De.GetIsoCode()).Build(),
            DesextrBuilder.ADesextrBuilder().WithIdioIsoCode(Language.Fr.GetIsoCode()).Build(),
            DesextrBuilder.ADesextrBuilder().WithIdioIsoCode(Language.Pt.GetIsoCode()).Build()
        };

        //when
        await pushStaticExtrasTranslations.Execute(givenDesextrs);

        //Then
        var expectedExtras = givenDesextrs.Select(x => new Infrastructure.Dtos.BookingCenter.Static.ExtraTranslation {
            ExtraCode = x.ExtraCode,
            Description = x.Detext,
            LanguageIsoCode = x.IdioIsoCode
        }).ToList();

        await staticSynchronizerApiClient.Received()
            .PushExtrasTranslations(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.ExtraTranslation>>(x => IsEquivalent(x, expectedExtras)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
