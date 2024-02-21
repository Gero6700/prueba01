namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Markup;

[TestFixture]
public class CreateMarkupShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMarkup createMarkup;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMarkup = new CreateMarkup(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_markup() {
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
        await createMarkup.Execute(anyMkupcabe);

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
            .CreateMarkup(Arg.Is<Infrastructure.Dtos.BookingCenter.Markup>(x => IsEquivalent(x, expectedMarkup)));
    }

    [Test]  
    public async Task do_not_create_markup_when_mkcbwd_is_null() {
        //Given
        const int anyMkcid = 1;
        const int anyMkcfed = 20240601;
        const int anyMkcfeh = 20240602;
        const decimal anyMkccpor = 5;
        var anyMkcgrb = new DateTime(2024, 1, 1);
        var anyMkcbwd = DateTime.MinValue;
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
        Func<Task> function = async () => await createMarkup.Execute(anyMkupcabe);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Booking window from is required");
    }

    [Test]
    public async Task do_not_create_markup_when_mkcbwh_is_null() {
        //Given
        const int anyMkcid = 1;
        const int anyMkcfed = 20240601;
        const int anyMkcfeh = 20240602;
        const decimal anyMkccpor = 5;
        var anyMkcgrb = new DateTime(2024, 1, 1);
        var anyMkcbwd = new DateTime(2024, 1, 1);
        var anyMkcbwh = DateTime.MinValue;

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
        Func<Task> function = async () => await createMarkup.Execute(anyMkupcabe);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Booking window to is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
