namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;

[TestFixture]
public class DeleteOfferAndSupplementGroupOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOfferSupplementGroupRelation deleteOfferAndSupplementGroupOfferAndSupplement;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOfferAndSupplementGroupOfferAndSupplement = new DeleteOfferSupplementGroupRelation(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_offer_and_supplement_group_offer_and_supplement() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteOfferAndSupplementGroupOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplementGroupOfferAndSupplement>(x => x.OfferSupplementGroupCode == anyOccin.ToString() && x.OfferSupplementCode == anyOfferSupplementCode));
    }

    [Test]
    public async Task do_not_delete_offer_and_supplement_group_offer_and_supplement_when_occin_is_zero() {
        //Given
        const int anyOccin = 0;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        Func<Task> function = async () => await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Group code is zero");
    }

    [Test]
    public async Task do_not_delete_offer_and_supplement_group_offer_and_supplement_when_offer_code_is_empty() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        Func<Task> function = async () => await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Offer code is empty");
    }


    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
