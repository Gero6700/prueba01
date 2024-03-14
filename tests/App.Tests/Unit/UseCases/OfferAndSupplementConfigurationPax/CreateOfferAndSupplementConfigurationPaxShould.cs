namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementConfigurationPax;

[TestFixture]
public class CreateOfferAndSupplementConfigurationPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOfferAndSupplementConfigurationPax createOfferAndSupplementConfigurationPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOfferAndSupplementConfigurationPax = new CreateOfferAndSupplementConfigurationPax();
    }

    [Test]
    public async Task create_offer_and_supplement_configuration_pax() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyOfferAndSupplementCode = "anyOfferAndSupplementCode";

        var condtof = new Condtof {
            O4tipa = anyO4tipa,
            O4dto = anyO4dto,
            O4desd = anyO4desd,
            O4has = anyO4has,
            O4dtos = anyO4dtos,
            Code = anyCode,
            OfferAndSupplementCode = anyOfferAndSupplementCode
        };

        //When
        await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
           PaxOrder = 1,
           PaxType = PaxType.Adult,
           Scope = ScopeType.Stay,
           AgeFrom = anyO4desd,
           AgeTo = anyO4has,
           Amount = anyO4dtos,
           AmountType = PaymentType.Percent
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
