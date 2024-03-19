namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementGroupOfferAndSupplement;

[TestFixture]
public class CreateOfferAndSupplementGroupOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOfferAndSupplementGroupOfferAndSupplement createOfferAndSupplementGroupOfferAndSupplement;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOfferAndSupplementGroupOfferAndSupplement = new CreateOfferAndSupplementGroupOfferAndSupplement(availabilitySynchronizerApiClient);    
    }

    [Test]
    public async Task create_offer_and_supplement_group_offer_and_supplement() {
        //Given
        const int anyOccin = 1;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            OfferSupCode = anyOfferSupplementCode
        };

        //When
        await createOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        var expectedOfferAndSupplementGroupOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementGroupOfferAndSupplement {
            OfferSupplementGroupCode = anyOccin.ToString(),
            OfferSupplementCode = anyOfferSupplementCode
        };
        
        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementGroupOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementGroupOfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplementGroupOfferAndSupplement)));
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_group_offer_and_supplement_when_occin_is_zero() { 
        //Given
        const int anyOccin = 0;
        const string anyOfferSupplementCode = "anyOfferSupplementCode";

        var conofcomLine = new ConofcomLine {
            Occin = anyOccin,
            OfferSupCode = anyOfferSupplementCode
        };

        //When
        Func<Task> function = async () => await createOfferAndSupplementGroupOfferAndSupplement.Execute(conofcomLine);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Group code is zero");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
