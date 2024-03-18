namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementConfigurationPax;
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
}
