namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.HotelRoomConfiguration;

[TestFixture]
public class UpdateHotelRoomConfigurationShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateHotelRoomConfiguration updateHotelRoomConfiguration;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateHotelRoomConfiguration = new UpdateHotelRoomConfiguration(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_hotel_room_configuration() {
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
        await updateHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        var expectedHotelRoomConfiguration = new Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration {
            HotelCode = anyTihote.ToString(),
            RoomCode = anyTihab,
            InventoryRoomTypeCode = anyTihabg,
            OccupancyRateCode = anyTiconf.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateHotelRoomConfiguration(Arg.Is<Infrastructure.Dtos.BookingCenter.HotelRoomConfiguration>(c => IsEquivalent(c, expectedHotelRoomConfiguration)));
    }

    [Test]
    public async Task do_not_update_hotel_room_configuration_when_tihote_is_zero() {
        //Given
        const int anyTihote = 0;
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
        Func<Task> function = async () => await updateHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect hotel code");
    }

    [Test]
    public async Task do_not_update_hotel_room_configuration_when_tihab_is_empty() {
        //Given
        const int anyTihote = 150;
        const string anyTihab = "";
        const string anyTihabg = "A1";
        const int anyTiconf = 1;

        var anyResthaho = new Resthaho {
            Tihote = anyTihote,
            Tihab = anyTihab,
            Tihabg = anyTihabg,
            Ticonf = anyTiconf
        };

        //When
        Func<Task> function = async () => await updateHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect room code");
    }

    [Test]
    public async Task do_not_update_hotel_room_configuration_when_tihabg_is_empty() {
        //Given
        const int anyTihote = 150;
        const string anyTihab = "A1";
        const string anyTihabg = "";
        const int anyTiconf = 1;

        var anyResthaho = new Resthaho {
            Tihote = anyTihote,
            Tihab = anyTihab,
            Tihabg = anyTihabg,
            Ticonf = anyTiconf
        };

        //When
        Func<Task> function = async () => await updateHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect inventory room type code");
    }

    [Test]
    public async Task do_not_update_hotel_room_configuration_when_ticonf_is_zero() {
        //Given
        const int anyTihote = 150;
        const string anyTihab = "A1";
        const string anyTihabg = "A1";
        const int anyTiconf = 0;

        var anyResthaho = new Resthaho {
            Tihote = anyTihote,
            Tihab = anyTihab,
            Tihabg = anyTihabg,
            Ticonf = anyTiconf
        };

        //When
        Func<Task> function = async () => await updateHotelRoomConfiguration.Execute(anyResthaho);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect occupancy rate code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

