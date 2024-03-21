using RabbitMQ.Client;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricing;

[TestFixture]
public class CreatePeriodPricingShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreatePeriodPricing createPeriodPricing;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createPeriodPricing = new CreatePeriodPricing();
    }

    [Test]
    public async Task create_period_pricing() {
        //Given
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";

        var anyConpreci = new Conpreci {
            Cffec = anyCffec,
            ContractClientCode = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele
        };

        //When
        await createPeriodPricing.Execute(anyConpreci);

        //Then
        var expectedPeriodPricing = new Infrastructure.Dtos.BookingCenter.PeriodPricing {
            PricingDate = new DateTime(2024, 01, 01),
            ContractClientCode = anyContractClientCode,
            StayPvp = anyC4esta,
            StayPvpApplyMode = ApplyStayPriceType.P,
            RegimePvp = anyC4serv,
            RegimePvpApplyMode = ApplyStayPriceType.P,
            OnRequest = false,
            Release = 0,
            RoomCode = anyC4thab,
            RegimeCode = anyC4tser
        };
    }
}
