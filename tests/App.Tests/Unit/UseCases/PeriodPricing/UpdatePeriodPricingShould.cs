using Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricing;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricing;

[TestFixture]
public class UpdatePeriodPricingShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdatePeriodPricing updatePeriodPricing;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updatePeriodPricing = new UpdatePeriodPricing();
    }

    [Test]
    public async Task update_period_pricing() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            RateCode = anyRateCode,
            Cffec = anyCffec,
            ContractClientCode = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele,
            Acrele = anyAcrele
        };

        //When
        await updatePeriodPricing.Execute(anyConpreci);

        //Then
        var expectedPeriodPricing = new Infrastructure.Dtos.BookingCenter.PeriodPricing {
            ClosingSales = false,
            RateCode = anyRateCode,
            PricingDate = new DateTime(2024, 01, 01),
            ContractClientCode = anyContractClientCode,
            StayPvp = anyC4esta,
            StayPvpApplyMode = ApplyStayPriceType.P,
            RegimePvp = anyC4serv,
            RegimePvpApplyMode = ApplyStayPriceType.P,
            OnRequest = false,
            Release = anyAcrele,
            RoomCode = anyC4thab,
            RegimeCode = anyC4tser
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
