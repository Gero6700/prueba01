namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementGroup;
public class DeleteOfferAndSupplementGroupShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOfferAndSupplementGroup deleteOfferAndSupplementGroup;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOfferAndSupplementGroup = new DeleteOfferAndSupplementGroup();    
    }

    [Test]
    public async Task delete_offer_and_supplement_group() {
        //Given
        const int anyOccin = 1;
        
        //When
        await deleteOfferAndSupplementGroup.Execute(anyOccin);

        //Then
        var expectedCode = "1";
        await availabilitySynchronizerApiClient.Received()
            .DeleteOfferAndSupplementGroup(Arg.Is<String>(x => IsEquivalent(x, expectedCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
