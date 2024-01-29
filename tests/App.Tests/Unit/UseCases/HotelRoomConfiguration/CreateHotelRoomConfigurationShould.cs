namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.HotelRoomConfiguration;

[TestFixture]
public class CreateHotelRoomConfigurationShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateHotelRoomConfiguration createHotelRoomConfiguration;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createHotelRoomConfiguration = new CreateHotelRoomConfiguration();
    }

    [Test]
    public async Task create_hotel_room_configuration() {
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
        await createHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        var expectedHotelRoomConfiguration = new Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration {
            HotelCode = anyTihote.ToString(),
            RoomCode = anyTihab,
            InventoryRoomTypeCode = anyTihabg,
            OcuppancyRateCode = anyTiconf.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateHotelRoomConfiguration(Arg.Is<Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration>(c => IsEquivalent(c, expectedHotelRoomConfiguration)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
