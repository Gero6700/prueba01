namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementGroupOfferAndSupplement;

[TestFixture]
public class DeleteOfferAndSupplementGroupOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOfferAndSupplementGroupOfferAndSupplement deleteOfferAndSupplementGroupOfferAndSupplement;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOfferAndSupplementGroupOfferAndSupplement = new DeleteOfferAndSupplementGroupOfferAndSupplement(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_offer_and_supplement_group_offer_and_supplement() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            OfferSupCode = anyOfferSupplementCode
        };

        //When
        await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteOfferAndSupplementGroupOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementGroupOfferAndSupplement>(x => x.OfferSupplementGroupCode == anyOccin.ToString() && x.OfferSupplementCode == anyOfferSupplementCode));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
