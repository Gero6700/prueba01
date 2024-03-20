namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementGroup;
public class DeleteOfferAndSupplementGroupShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOfferAndSupplementGroup deleteOfferAndSupplementGroup;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOfferAndSupplementGroup = new DeleteOfferAndSupplementGroup(availabilitySynchronizerApiClient);    
    }

    [Test]
    public async Task delete_offer_and_supplement_group() {
        //Given
        const int anyOccin = 1;

       var conofcomHeader = new ConofcomHeader {
            Occin = anyOccin
        };
        
        //When
        await deleteOfferAndSupplementGroup.Execute(conofcomHeader);

        //Then
        var expectedCode = "1";
        await availabilitySynchronizerApiClient.Received()
            .DeleteOfferAndSupplementGroup(Arg.Is<String>(x => IsEquivalent(x, expectedCode)));
    }

    [Test]
    public async Task do_not_delete_offer_and_supplement_group_when_occin_is_zero() {
        //Given
        const int anyOccin = 0;

        var conofcomHeader = new ConofcomHeader {
            Occin = anyOccin
        };
        
        //When
        Func<Task> function = async () => await deleteOfferAndSupplementGroup.Execute(conofcomHeader);

        //Then
        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Group code is zero");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
