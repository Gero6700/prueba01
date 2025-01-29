namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;

[TestFixture]
public class CreateOfferAndSupplementGroupOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOfferSupplementGroupRelation createOfferAndSupplementGroupOfferAndSupplement;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOfferAndSupplementGroupOfferAndSupplement = new CreateOfferSupplementGroupRelation(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_offer_and_supplement_group_offer_and_supplement() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        await createOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        var expectedOfferAndSupplementGroupOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplementGroupOfferAndSupplement {
            OfferSupplementGroupCode = anyOccin.ToString(),
            OfferSupplementCode = anyOfferSupplementCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementGroupOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplementGroupOfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplementGroupOfferAndSupplement)));
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_group_offer_and_supplement_when_occin_is_zero() {
        //Given
        const int anyOccin = 0;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        Func<Task> function = async () => await createOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Group code is zero");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_group_offer_and_supplement_when_offer_code_is_empty() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            Oocode = anyOfferSupplementCode
        };

        //When
        Func<Task> function = async () => await createOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Offer code is empty");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
