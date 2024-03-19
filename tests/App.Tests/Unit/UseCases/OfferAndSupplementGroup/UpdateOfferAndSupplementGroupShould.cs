using Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroup;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplementGroup;
[TestFixture]
public class UpdateOfferAndSupplementGroupShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateOfferAndSupplementGroup updateOfferAndSupplementGroup;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateOfferAndSupplementGroup = new UpdateOfferAndSupplementGroup(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_offer_and_supplement_group() {
        //Given
        const int anyOccin = 1;
        const int anyOcfec1 = 20240101;
        const int anyOcfec2 = 20240102;

        var anyConofcomHeader = new ConofcomHeader {
            Occin = anyOccin,
            Ocfec1 = anyOcfec1,
            Ocfec2 = anyOcfec2
        };

        //When
        await updateOfferAndSupplementGroup.Execute(anyConofcomHeader);

        //Then
        var expectedOfferAndSupplementGroup = new Infrastructure.Dtos.BookingCenter.OfferAndSupplementGroup {
            Code = "1",
            ApplyFrom = new DateTime(2024, 1, 1),
            ApplyTo = new DateTime(2024, 1, 2)
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateOfferAndSupplementGroup(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplementGroup>(x => IsEquivalent(x, expectedOfferAndSupplementGroup)));
    }

    [Test]
    public async Task do_not_update_offer_and_supplement_group_when_ocfec2_is_less_than_ocfec1_and_they_are_not_zero() {
        //Given
        const int anyOccin = 1;
        const int anyOcfec1 = 20240102;
        const int anyOcfec2 = 20240101;

        var anyConofcomHeader = new ConofcomHeader {
            Occin = anyOccin,
            Ocfec1 = anyOcfec1,
            Ocfec2 = anyOcfec2
        };

        //When
        Func<Task> function = async () => await updateOfferAndSupplementGroup.Execute(anyConofcomHeader);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Apply to date is less than apply from date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
