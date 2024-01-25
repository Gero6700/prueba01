namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Hotel;

[TestFixture]
public class UpdateHotelShould {
    IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    UpdateHotel updateHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateHotel = new UpdateHotel(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_hotel() {
        //Given
        var anyHotcod = 1234;
        var anyHozhor = "anyHozhor";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor
        };

        //When
        await updateHotel.Execute(anyReshotel);

        //Then
        var expectedHotel = new Infrastructure.Dtos.BookingCenter.Hotel {
            Code = anyHotcod.ToString(),
            TimeZone = anyHozhor.ToString(),
        };
        
        await availabilitySynchronizerApiClient.Received()
            .UpdateHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Hotel>(c => IsEquivalent(c, expectedHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

