namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.HotelRoomConfiguration;

[TestFixture]   
public class DeleteHotelRoomConfigurationShould
{
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteHotelRoomConfiguration deleteHotelRoomConfiguration;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteHotelRoomConfiguration = new DeleteHotelRoomConfiguration();
    }

    [Test]
    public async Task delete_hotel_room_configuration() {
        //Given
        const int anyTihote = 150;
        const string anyTihab = "A1";
        const string anyTihabg = "A1";
        const int anyTiconf = 1;

        var anyResthaho = new Resthaho {
            Tihote = anyTihote,
            Tihab = anyTihab,
            Tihabg = anyTihabg,
            Ticonf = anyTiconf
        };
        
        //When
        await deleteHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        var expectedHotelRoomConfiguration = new Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration {
            HotelCode = anyTihote.ToString(),
            RoomCode = anyTihab,
            InventoryRoomTypeCode = anyTihabg,
            OcuppancyRateCode = anyTiconf.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .DeleteHotelRoomConfiguration(Arg.Is<Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration>(c => IsEquivalent(c, expectedHotelRoomConfiguration)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
