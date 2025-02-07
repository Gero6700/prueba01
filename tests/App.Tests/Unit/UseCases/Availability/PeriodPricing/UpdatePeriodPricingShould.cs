namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.PeriodPricing;

[TestFixture]
public class UpdatePeriodPricingShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdatePeriodPricing updatePeriodPricing;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updatePeriodPricing = new UpdatePeriodPricing(availabilitySynchronizerApiClient);
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
        const string anyTior = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele,
            Tior = anyTior,
            Acrele = anyAcrele
        };

        //When
        await updatePeriodPricing.Execute(anyConpreci);

        //Then
        var expectedPeriodPricing = new Infrastructure.Dtos.BookingCenter.Availability.PeriodPricing {
            ClosingSales = false,
            RateCode = anyRateCode,
            PricingDate = new DateTime(2024, 01, 01),
            IntegrationContractId = anyContractClientCode,
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
            .UpdatePeriodPricing(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.PeriodPricing>(x => IsEquivalent(x, expectedPeriodPricing)));
    }

    [Test]
    public async Task do_not_update_period_pricing_when_cffec_is_zero() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 0;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const string anyTior = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele,
            Tior = anyTior,
            Acrele = anyAcrele
        };

        //When
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Price date is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_cffec_is_invalid() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const string anyTior = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele,
            Tior = anyTior,
            Acrele = anyAcrele
        };

        //When
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid price date");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_c4thab_is_empty() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const string anyTior = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
            C4esta = anyC4esta,
            C4form = anyC4form,
            C4serv = anyC4serv,
            C4fors = anyC4fors,
            C4thab = anyC4thab,
            C4tser = anyC4tser,
            Rerele = anyRerele,
            Tior = anyTior,
            Acrele = anyAcrele
        };

        //When
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Room code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_c4tser_is_empty() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClient";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "";
        const string anyRerele = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
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
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Regime code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_contract_client_code_is_empty() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
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
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Contract client code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_rate_code_is_empty() {
        //Given
        const string anyRateCode = "";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClientCode";
        const decimal anyC4esta = 24.99m;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
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
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Rate code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_when_c4esta_is_zero() {
        //Given
        const string anyRateCode = "anyRateCode";
        const int anyCffec = 2024001;
        const string anyContractClientCode = "anyContractClientCode";
        const decimal anyC4esta = 0;
        const string anyC4form = "";
        const decimal anyC4serv = 9.99m;
        const string anyC4fors = "";
        const string anyC4thab = "anyC4thab";
        const string anyC4tser = "anyC4tser";
        const string anyRerele = "";
        const int anyAcrele = 0;

        var anyConpreci = new Conpreci {
            C4rcode = anyRateCode,
            C4fec = anyCffec,
            C4ccod = anyContractClientCode,
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
        Func<Task> act = async () => await updatePeriodPricing.Execute(anyConpreci);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Stay price must be greater than zero");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
