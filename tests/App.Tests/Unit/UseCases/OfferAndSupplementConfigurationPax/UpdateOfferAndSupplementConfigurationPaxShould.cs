using Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementConfigurationPax;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementConfigurationPax;

[TestFixture]
public class UpdateOfferAndSupplementConfigurationPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateOfferAndSupplementConfigurationPax updateOfferAndSupplementConfigurationPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateOfferAndSupplementConfigurationPax = new UpdateOfferAndSupplementConfigurationPax(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_offer_and_supplement_configuration_pax() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 18.00m;
        const decimal anyO4has = 99.99m;
        const decimal anyO4dtos = 0.00m;
        const string anyCode = "anyCode";
        const string anyOfferAndSupplementCode = "anyOfferAndSupplementCode";

        var condtof = new Condtof {
            O4tipa = anyO4tipa,
            O4tdto = anyO4dto,
            O4desd = anyO4desd,
            O4has = anyO4has,
            O4dtos = anyO4dtos,
            Code = anyCode,
            OfferAndSupplementCode = anyOfferAndSupplementCode
        };

        //When
        await updateOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
           PaxOrder = 1,
           PaxType = PaxType.Adult,
           Scope = ScopeType.Stay,
           AgeFrom = anyO4desd,
           AgeTo = anyO4has,
           Amount = anyO4dtos,
           AmountType = PaymentType.Percent,
           OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
           Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task do_not_update_offer_and_supplement_configuration_pax_when_code_is_empty() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
        const string anyCode = "";
        const string anyOfferAndSupplementCode = "anyOfferAndSupplementCode";

        var condtof = new Condtof {
            O4tipa = anyO4tipa,
            O4tdto = anyO4dto,
            O4desd = anyO4desd,
            O4has = anyO4has,
            O4dtos = anyO4dtos,
            Code = anyCode,
            OfferAndSupplementCode = anyOfferAndSupplementCode
        };

        //When
        Func<Task> function = async () => await updateOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_update_offer_and_supplement_configuration_pax_when_offer_and_supplement_code_is_empty() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyOfferAndSupplementCode = "";

        var condtof = new Condtof {
            O4tipa = anyO4tipa,
            O4tdto = anyO4dto,
            O4desd = anyO4desd,
            O4has = anyO4has,
            O4dtos = anyO4dtos,
            Code = anyCode,
            OfferAndSupplementCode = anyOfferAndSupplementCode
        };

        //When
        Func<Task> function = async () => await updateOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("OfferAndSupplement code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
