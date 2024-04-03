namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.OfferAndSupplementConfigurationPax;
[TestFixture]
public class DeleteOfferAndSupplementConfigurationPaxShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOfferAndSupplementConfigurationPax deleteOfferAndSupplementConfigurationPax;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOfferAndSupplementConfigurationPax = new DeleteOfferAndSupplementConfigurationPax(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_offer_and_supplement_configuration_pax() {
        //Given
        const string anyCode = "anyCode";

        //When
        await deleteOfferAndSupplementConfigurationPax.Execute(anyCode);

        //Then
        await availabilitySynchronizerApiClient.Received().DeleteOfferAndSupplementConfigurationPax(anyCode);
    }

    [Test]
    public async Task do_not_delete_offer_and_supplement_configuration_pax_when_code_is_empty() {
        //Given
        const string anyCode = "";

        //When
        Func<Task> function = async () => await deleteOfferAndSupplementConfigurationPax.Execute(anyCode);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }
}
