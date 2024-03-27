namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.PeriodPricingPax;

[TestFixture]
public class DeletePeriodPricingPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeletePeriodPricingPax deletePeriodPricingPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deletePeriodPricingPax = new DeletePeriodPricingPax();
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

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
