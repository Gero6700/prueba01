namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricingPax;

[TestFixture]
public class CreatePeriodPricingPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreatePeriodPricingPax createPeriodPricingPax;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createPeriodPricingPax = new CreatePeriodPricingPax(availabilitySynchronizerApiClient);
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

    [Test]
    public async Task create_period_pricing_pax_when_d4tipa_is_niños() {
        //Given
        const string anyD4tipa = "NIÑOS1";
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
            PaxType = PaxType.Child,
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

    [Test]
    public async Task create_period_pricing_pax_when_d4tipa_is_adult_and_d4has_is_less_than_18() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "";
        const decimal anyD4desd = 13.00m;
        const decimal anyD4has = 17.99m;
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
            PaxType = PaxType.Teenager,
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

    [Test]
    public async Task create_period_pricing_pax_when_d4tdto_is_e() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "E";
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

    [Test]
    public async Task create_period_pricing_pax_when_d4dto_is_s() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "S";
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
            Scope = ScopeType.Regime,
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

    [Test]
    public async Task do_not_create_period_pricing_pax_when_code_is_empty() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "";
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
        Func<Task> function = async () =>  await createPeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_create_period_pricing_pax_when_period_pricing_code_is_empty() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyPeriodPricingCode = "";

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
        Func<Task> function = async () =>  await createPeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Period pricing code is required");
    }

    [Test]
    public async Task do_not_create_period_pricing_pax_when_d4tipa_is_empty() {
        //Given
        const string anyD4tipa = "";
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
        Func<Task> function = async () =>  await createPeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type is required");
    }

    [Test]
    public async Task do_not_create_period_pricing_pax_when_d4tipa_length_is_less_than_6() {
        //Given
        const string anyD4tipa = "ADULT";
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
        Func<Task> function = async () =>  await createPeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type length is less than 6");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
