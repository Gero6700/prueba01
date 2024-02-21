namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Markup;
[TestFixture]
public class UpdateMarkupShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateMarkup updateMarkup;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateMarkup = new UpdateMarkup(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_markup() {
        //Given
        const int anyMkcid = 1;
        const int anyMkcfed = 20240601;
        const int anyMkcfeh = 20240602;
        const decimal anyMkccpor = 5;
        var anyMkcgrb = new DateTime(2024, 1, 1);
        var anyMkcbwd = new DateTime(2024, 1, 1);
        var anyMkcbwh = new DateTime(2024, 12, 31);

        var anyMkupcabe = new Mkupcabe {
            Mkcid = anyMkcid,
            Mkcgrb = anyMkcgrb,
            Mkcbwd = anyMkcbwd,
            Mkcbwh = anyMkcbwh,
            Mkcfed = anyMkcfed,
            Mkcfeh = anyMkcfeh,
            Mkccpor = anyMkccpor
        };

        //When
        await updateMarkup.Execute(anyMkupcabe);

        //Then
        var expectedMarkup = new Infrastructure.Dtos.BookingCenter.Markup {
            Code = anyMkcid.ToString(),
            CreationDate = anyMkcgrb,
            BookingWindowFrom = anyMkcbwd,
            BookingWindowTo = anyMkcbwh,
            StayFrom = new DateTime(2024, 6, 1),
            StayTo = new DateTime(2024, 6, 2),
            Amount = anyMkccpor
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateMarkup(Arg.Is<Infrastructure.Dtos.BookingCenter.Markup>(x => IsEquivalent(x, expectedMarkup)));

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
