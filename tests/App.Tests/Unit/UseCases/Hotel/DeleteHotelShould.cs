namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Hotel;

[TestFixture]
public class DeleteHotelShould {
    IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    DeleteHotel deleteHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteHotel = new DeleteHotel();
    }

    [Test]
    public async Task delete_hotel() {
        //Given
        var anyHotcod = 1234;
        var anyHozhor = "anyHozhor";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor
        };

        //When
        await deleteHotel.Execute(anyReshotel);

        //Then
        var expectedHotel = new Infrastructure.Dtos.BookingCenter.Hotel {
            Code = anyHotcod.ToString(),
            TimeZone = anyHozhor.ToString(),
        };
        
        await availabilitySynchronizerApiClient.Received()
            .DeleteHotel(Arg.Is<string>(c => IsEquivalent(c, expectedHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

