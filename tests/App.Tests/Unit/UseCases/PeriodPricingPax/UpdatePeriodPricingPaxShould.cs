using Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricingPax;

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

    [Test]
    public async Task do_not_update_period_pricing_pax_when_code_is_empty() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "E";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "";
        const string anyPeriodPricingCode = "anyPeriodPricingCode";

        var anyCondtos = new Condtos {
            Code = anyCode,
            D4tipa = anyD4tipa,
            D4tdto = anyD4tdto,
            D4desd = anyD4desd,
            D4has = anyD4has,
            D4dtos = anyD4dtos,
            PeriodPricingCode = anyPeriodPricingCode
        };

        //When
        Func<Task> action = async () => await updatePeriodPricingPax.Execute(anyCondtos);

        //Then
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_pax_when_period_pricing_code_is_empty() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "E";
        const decimal anyD4desd = 20.00m;
        const decimal anyD4has = 21.99m;
        const decimal anyD4dtos = 10.00m;
        const string anyCode = "anyCode";
        const string anyPeriodPricingCode = "";

        var anyCondtos = new Condtos {
            Code = anyCode,
            D4tipa = anyD4tipa,
            D4tdto = anyD4tdto,
            D4desd = anyD4desd,
            D4has = anyD4has,
            D4dtos = anyD4dtos,
            PeriodPricingCode = anyPeriodPricingCode
        };

        //When
        Func<Task> action = async () => await updatePeriodPricingPax.Execute(anyCondtos);

        //Then
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Period pricing code is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_pax_when_d4tipa_is_empty() {
        //Given
        const string anyD4tipa = "";
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
        Func<Task> function = async () => await updatePeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type is required");
    }

    [Test]
    public async Task do_not_update_period_pricing_pax_when_d4tipa_length_is_less_than_6() {
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
        Func<Task> function = async () => await updatePeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type length is less than 6");
    }

    [Test]
    public async Task do_not_update_period_pricing_pax_when_d4tipa_position_5_is_not_a_number() {
        //Given
        const string anyD4tipa = "ADULTA";
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
        Func<Task> function = async () => await updatePeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax order is not a number");
    }

    [Test]
    public async Task do_not_update_period_pricing_pax_when_d4has_is_less_than_d4desd() {
        //Given
        const string anyD4tipa = "ADULT1";
        const string anyD4tdto = "";
        const decimal anyD4desd = 21.00m;
        const decimal anyD4has = 20.99m;
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
        Func<Task> function = async () => await updatePeriodPricingPax.Execute(condtos);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Age to is less than age from");
    }


    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
