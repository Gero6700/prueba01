namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Hotel;

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
        var anyProvinceCode = "anyProvinceCode";
        var anyCityCode = "anyCityCode";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor,
            ProvinceCode = anyProvinceCode,
            CityCode = anyCityCode
        };

        //When
        await updateHotel.Execute(anyReshotel);

        //Then
        var expectedHotel = new Infrastructure.Dtos.BookingCenter.Availability.Hotel {
            Code = anyHotcod.ToString(),
            TimeZone = anyHozhor.ToString(),
            ProvinceCode = anyProvinceCode,
            CityCode = anyCityCode
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Hotel>(c => IsEquivalent(c, expectedHotel)));
    }

    [Test]
    public async Task do_not_update_hotel_when_hotcod_is_zero() {
        //Given
        var anyHotcod = 0;
        var anyHozhor = "anyHozhor";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor
        };

        //When
        Func<Task> function = async () => await updateHotel.Execute(anyReshotel);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid hotel code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

