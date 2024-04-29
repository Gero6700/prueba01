using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.OfferAndSupplementTranslation;

[TestFixture]
public class PushStaticOffersAndSuplementsTranslationsShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticOffersAndSupplementsTranslations pushStaticOffersAndSupplementsTranslations;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticOffersAndSupplementsTranslations = new PushStaticOffersAndSupplementsTranslations();
    }

    [Test]
    public async Task push_static_offers_and_supplements_translations() {
        //Given
        var givenDesofers = new List<Desofer>() {
            DesoferBuilder.ADesoferBuilder().WithIdioIsoCode(Language.Es.GetIsoCode()).Build(),
            DesoferBuilder.ADesoferBuilder().WithIdioIsoCode(Language.En.GetIsoCode()).Build(),
            DesoferBuilder.ADesoferBuilder().WithIdioIsoCode(Language.De.GetIsoCode()).Build(),
            DesoferBuilder.ADesoferBuilder().WithIdioIsoCode(Language.Fr.GetIsoCode()).Build(),
            DesoferBuilder.ADesoferBuilder().WithIdioIsoCode(Language.Pt.GetIsoCode()).Build()
        };

        //when
        await pushStaticOffersAndSupplementsTranslations.Execute(givenDesofers);

        //Then
        var expectedOffersAndSupplements = givenDesofers.Select(x => new Infrastructure.Dtos.BookingCenter.Static.OfferAndSupplementTranslation {
            OfferAndSupplementCode = x.ConofegeCode,
            Description = x.Dotext,
            LanguageIsoCode = x.IdioIsoCode
        }).ToList();

        await staticSynchronizerApiClient.Received()
            .PushOffersAndSupplementsTranslations(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.OfferAndSupplementTranslation>>(x => IsEquivalent(x, expectedOffersAndSupplements)));

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
