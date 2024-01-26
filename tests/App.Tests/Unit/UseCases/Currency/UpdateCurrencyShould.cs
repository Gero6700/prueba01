using Senator.As400.Cloud.Sync.Application.UseCases.Currency;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Currency;

[TestFixture]
public class UpdateCurrencyShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;
    private UpdateCurrency updateCurrency = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateCurrency = new UpdateCurrency(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_currency() {
        //Given
        const string anyDinom2 = "EUR";
        const string anyDinomb = "anyDinomb";
        const string anyDisimb = "anyDisimb";

        var anyDivisa = new Divisa {
            Dinom2 = anyDinom2,
            Dinomb = anyDinomb,
            Disimb = anyDisimb
        };

        //When
        await updateCurrency.Execute(anyDivisa);

        //Then
        var expectedCurrency = new Infrastructure.Dtos.BookingCenter.Currency {
            IsoCode = anyDinom2,
            Description = anyDinomb,
            Symbol = anyDisimb
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateCurrency(Arg.Is<Infrastructure.Dtos.BookingCenter.Currency>(c => IsEquivalent(c, expectedCurrency)));
    }


    [Test]
    public async Task do_not_update_currency_when_dinomb2_is_empty() {
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
        Func<Task> function = async () => await updateCurrency.Execute(anyDivisa);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect currency code");
    }

    [Test]
    public async Task do_not_update_currency_when_dinomb2_is_invalid() {
        //Then
        const string anyDinom2 = "EU0";
        const string anyDinomb = "anyDinomb";
        const string anyDisimb = "anyDisimb";

        var anyDivisa = new Divisa {
            Dinom2 = anyDinom2,
            Dinomb = anyDinomb,
            Disimb = anyDisimb
        };

        //When
        Func<Task> function = async () => await updateCurrency.Execute(anyDivisa);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid iso code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}

