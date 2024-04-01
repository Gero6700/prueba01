namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricingPax;

[TestFixture]
public class DeletePeriodPricingPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeletePeriodPricingPax deletePeriodPricingPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deletePeriodPricingPax = new DeletePeriodPricingPax(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_period_pricing_pax() {
        //Given
        const string anyCode = "anyCode";

        //When
        await deletePeriodPricingPax.Execute(anyCode);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeletePeriodPricingPax(Arg.Is<string>(x => IsEquivalent(x, anyCode)));
    }

    [Test]
    public async Task do_not_delete_period_pricing_pax_when_code_is_empty() {
        //Given
        const string anyCode = "";

        //When
        Func<Task> function = async () => await deletePeriodPricingPax.Execute(anyCode);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
