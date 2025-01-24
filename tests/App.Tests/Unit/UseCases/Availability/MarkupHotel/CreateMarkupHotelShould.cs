namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.MarkupHotel;

[TestFixture]
public class CreateMarkupHotelShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMarkupHotel createMarkupHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMarkupHotel = new CreateMarkupHotel(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_markup_hotel() {
        //Given
        const int anyMkhidc = 1;
        const int anyMkhhot = 1;

        var anyMkuphote = new Mkuphote {
            Mkhidc = anyMkhidc,
            Mkhhot = anyMkhhot
        };

        //When
        createMarkupHotel.Execute(anyMkuphote);

        //Then
        var expectedMarkupHotel = new Infrastructure.Dtos.BookingCenter.Availability.MarkupHotel {
            HotelCode = anyMkhidc.ToString(),
            MarkupCode = anyMkhhot.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateMarkupHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.MarkupHotel>(x => IsEquivalent(x, expectedMarkupHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
