namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricingPax;

[TestFixture]
public class CreatePeriodPricingPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreatePeriodPricingPax createPeriodPricingPax;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createPeriodPricingPax = new CreatePeriodPricingPax();
    }

    [Test]
    public async Task create_period_pricing_pax() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyPeriodPricingCode = "anyPeriodPricingCode";

        var condtos = new Condtos {
            Code = anyCode,
            D4tipa = anyD4tipa,
            D4tdto = anyD4tdto,
            D4desd = anyD4desd,
            D4has = anyD4has,
            D4dtos = anyD4dtos,
            PeriodPricingCode = anyPeriodPricingCode
        };

        //When
        await createPeriodPricingPax.Execute(condtos);

        //Then
        var expectedPeriodPricingPax = new Infrastructure.Dtos.BookingCenter.PeriodPricingPax {
            PaxOrder = 1,
            PaxType = PaxType.Adult,
            Scope = ScopeType.Stay,
            AgeFrom = anyD4desd,
            AgeTo = anyD4has,
            Amount = anyD4dtos,
            AmountType = PaymentType.Percent,
            PeriodPricingCode = anyPeriodPricingCode,
            Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreatePeriodPricingPax(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricingPax>(x => IsEquivalent(x, expectedPeriodPricingPax)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
