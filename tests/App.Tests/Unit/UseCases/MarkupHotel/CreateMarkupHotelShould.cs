namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.MarkupHotel;

[TestFixture]
public class CreateMarkupHotelShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMarkupHotel createMarkupHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMarkupHotel = new CreateMarkupHotel();
    }

    [Test]
    public async Task create_markup_hotel() {
        //Given
        const int anyMkhidc = 1;
        const int anyMkhhot = 1;
        
        var anyMkuphote = new Infrastructure.Dtos.As400.Mkuphote {
            Mkhidc = anyMkhidc,
            Mkhhot = anyMkhhot.ToString()
        };

        //When
        await createMarkupHotel.Execute(anyMkuphote);

        //Then
        var expectedMarkupHotel = new Infrastructure.Dtos.BookingCenter.MarkupHotel {
            HotelCode = anyMkhidc,
            MarkupCode = anyMkhhot
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateMarkupHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.MarkupHotel>(x => IsEquivalent(x, expectedMarkupHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
