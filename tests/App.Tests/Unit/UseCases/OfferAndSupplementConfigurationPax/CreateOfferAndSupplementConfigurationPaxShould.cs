namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementConfigurationPax;

[TestFixture]
public class CreateOfferAndSupplementConfigurationPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOfferAndSupplementConfigurationPax createOfferAndSupplementConfigurationPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOfferAndSupplementConfigurationPax = new CreateOfferAndSupplementConfigurationPax(availabilitySynchronizerApiClient);
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
            O4tdto = anyO4dto,
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
           AmountType = PaymentType.Percent,
           OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
           Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task create_offer_and_supplement_configuration_pax_when_o4tipa_is_niños() {
        //Given
        const string anyO4tipa = "NIÑOS1";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
            PaxOrder = 1,
            PaxType = PaxType.Child,
            Scope = ScopeType.Stay,
            AgeFrom = anyO4desd,
            AgeTo = anyO4has,
            Amount = anyO4dtos,
            AmountType = PaymentType.Percent,
            OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
            Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task create_offer_and_supplement_configuration_pax_when_o4dto_is_e() {
        //Given
        const string anyO4tipa = "NIÑOS1";
        const string anyO4dto = "E";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
            PaxOrder = 1,
            PaxType = PaxType.Child,
            Scope = ScopeType.Stay,
            AgeFrom = anyO4desd,
            AgeTo = anyO4has,
            Amount = anyO4dtos,
            AmountType = PaymentType.Percent,
            OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
            Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task create_offer_and_supplement_configuration_pax_when_o4dto_is_s() {
        //Given
        const string anyO4tipa = "NIÑOS1";
        const string anyO4dto = "S";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
            PaxOrder = 1,
            PaxType = PaxType.Child,
            Scope = ScopeType.Regime,
            AgeFrom = anyO4desd,
            AgeTo = anyO4has,
            Amount = anyO4dtos,
            AmountType = PaymentType.Percent,
            OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
            Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task create_offer_and_supplement_configuration_pax_when_o4tipa_is_adult_and_o4has_is_less_18() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 13.00m;
        const decimal anyO4has = 17.99m;
        const decimal anyO4dtos = 10.00m;
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
        await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        var expectedOfferAndSupplementConfigurationPax = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax {
            PaxOrder = 1,
            PaxType = PaxType.Teenager,
            Scope = ScopeType.Stay,
            AgeFrom = anyO4desd,
            AgeTo = anyO4has,
            Amount = anyO4dtos,
            AmountType = PaymentType.Percent,
            OfferAndSupplementConfigurationCode = anyOfferAndSupplementCode,
            Code = anyCode
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplementConfigurationPax(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementConfigurationPax>(x => IsEquivalent(x, expectedOfferAndSupplementConfigurationPax)));
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_code_is_empty() {
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");     
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_offer_and_supplement_code_is_empty() {
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("OfferAndSupplement Code is required");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_o4has_is_less_than_o4desd() {
        //Given
        const string anyO4tipa = "ADULT1";
        const string anyO4dto = "";
        const decimal anyO4desd = 21.00m;
        const decimal anyO4has = 20.99m;
        const decimal anyO4dtos = 10.00m;
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Age to is less than age from");

    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_o4tipa_is_empty() {
        //Given
        const string anyO4tipa = "";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type is required");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_o4tipa_lenght_is_less_than_6() {
        //Given
        const string anyO4tipa = "ADULT";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax type lenght is less than 6");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_configuration_pax_when_o4tipa_position_5_is_not_a_number() {
        //Given
        const string anyO4tipa = "ADULTA";
        const string anyO4dto = "";
        const decimal anyO4desd = 20.00m;
        const decimal anyO4has = 21.99m;
        const decimal anyO4dtos = 10.00m;
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
        Func<Task> function = async () => await createOfferAndSupplementConfigurationPax.Execute(condtof);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Pax order is not a number");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
