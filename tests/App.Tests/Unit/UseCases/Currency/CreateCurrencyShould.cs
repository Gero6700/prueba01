using FluentAssertions.Specialized;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Currency;

[TestFixture]
public class CreateCurrencyShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;
    private CreateCurrency createCurrency = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createCurrency = new CreateCurrency(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_currency() {
        //Given
        const string anyDinom2 = "anyDinom2";
        const string anyDinomb = "anyDinomb";
        const string anyDisimb = "anyDisimb";

        var anyDivisa = new Divisa {
            Dinom2 = anyDinom2,
            Dinomb = anyDinomb,
            Disimb = anyDisimb
        };

        //When
        await createCurrency.Execute(anyDivisa);

        //Then
        var expectedCurrency = new Infrastructure.Dtos.BookingCenter.Currency {
            IsoCode = anyDinom2,
            Description = anyDinomb,
            Symbol = anyDisimb
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateCurrency(Arg.Is<Infrastructure.Dtos.BookingCenter.Currency>(c => IsEquivalent(c, expectedCurrency)));
    }

    [Test]
    public async Task do_not_create_currency_when_dinomb2_is_empty() {
        //Then
        const string anyDinom2 = "";
        const string anyDinomb = "anyDinomb";
        const string anyDisimb = "anyDisimb";

        var anyDivisa = new Divisa {
            Dinom2 = anyDinom2,
            Dinomb = anyDinomb,
            Disimb = anyDisimb
        };

        //When
        Func<Task> function = async () => await createCurrency.Execute(anyDivisa);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect currency code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

