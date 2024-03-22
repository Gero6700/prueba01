using RabbitMQ.Client;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricing;

[TestFixture]
public class CreatePeriodPricingShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreatePeriodPricing createPeriodPricing;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createPeriodPricing = new CreatePeriodPricing(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_period_pricing() {
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
        await createPeriodPricing.Execute(anyConpreci);

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
            .CreatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    [Test]
    public async Task create_period_pricing_when_c4form_is_p() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "P";
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
        await createPeriodPricing.Execute(anyConpreci);

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
            .CreatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    [Test]
    public async Task create_period_pricing_when_c4form_is_d() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "D";
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
        await createPeriodPricing.Execute(anyConpreci);

        //Then
        var expectedPeriodPricing = new Infrastructure.Dtos.BookingCenter.PeriodPricing {
            ClosingSales = false,
            RateCode = anyRateCode,
            PricingDate = new DateTime(2024, 01, 01),
            ContractClientCode = anyContractClientCode,
            StayPvp = anyC4esta,
            StayPvpApplyMode = ApplyStayPriceType.D,
            RegimePvp = anyC4serv,
            RegimePvpApplyMode = ApplyStayPriceType.P,
            OnRequest = false,
            Release = anyAcrele,
            RoomCode = anyC4thab,
            RegimeCode = anyC4tser
        };

        await availabilitySynchronizerApiClient.Received()
            .CreatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    [Test]
    public async Task create_period_pricing_when_c4fors_is_p() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "P";
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
        await createPeriodPricing.Execute(anyConpreci);

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
            .CreatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    [Test]
    public async Task create_period_pricing_when_c4fors_is_d() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "D";
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
        await createPeriodPricing.Execute(anyConpreci);

        //Then
        var expectedPeriodPricing = new Infrastructure.Dtos.BookingCenter.PeriodPricing {
            ClosingSales = false,
            RateCode = anyRateCode,
            PricingDate = new DateTime(2024, 01, 01),
            ContractClientCode = anyContractClientCode,
            StayPvp = anyC4esta,
            StayPvpApplyMode = ApplyStayPriceType.P,
            RegimePvp = anyC4serv,
            RegimePvpApplyMode = ApplyStayPriceType.D,
            OnRequest = false,
            Release = anyAcrele,
            RoomCode = anyC4thab,
            RegimeCode = anyC4tser
        };

        await availabilitySynchronizerApiClient.Received()
            .CreatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
