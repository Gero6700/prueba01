namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Hotel;

[TestFixture]
public class CreateHotelShould {
    IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    CreateHotel createHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createHotel = new CreateHotel();
    }

    [Test]
    public async Task create_hotel() {
        //Given
        var anyHotcod = 1234;
        var anyHozhor = "anyHozhor";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor
        };

        //When
        await createHotel.Execute(anyReshotel);

        //Then
        var expectedHotel = new Infrastructure.Dtos.BookingCenter.Hotel {
            Code = anyHotcod.ToString(),
            TimeZone = anyHozhor.ToString(),
        };
        
        await availabilitySynchronizerApiClient.Received()
            .CreateHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Hotel>(c => IsEquivalent(c, expectedHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

