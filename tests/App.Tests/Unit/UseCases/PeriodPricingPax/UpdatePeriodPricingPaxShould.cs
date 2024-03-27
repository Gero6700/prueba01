namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricingPax;

[TestFixture]
public class UpdatePeriodPricingPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdatePeriodPricingPax updatePeriodPricingPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updatePeriodPricingPax = new UpdatePeriodPricingPax(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_period_pricing_pax() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "E";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyPeriodPricingCode = "anyPeriodPricingCode";

        var anyCondtos = new Condtos {
            D4tipa = anyD4tipa,
            D4tdto = anyD4tdto,
            D4desd = anyD4desd,
            D4has = anyD4has,
            D4dtos = anyD4dtos,
            Code = anyCode,
            PeriodPricingCode = anyPeriodPricingCode
        };

        //When
        await updatePeriodPricingPax.Execute(anyCondtos);

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
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
