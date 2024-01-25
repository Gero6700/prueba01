namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Hotel;

[TestFixture]
public class CreateHotelShould {
    IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    CreateHotel createHotel;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createHotel = new CreateHotel(availabilitySynchronizerApiClient);
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

    [Test]
    public async Task do_not_create_hotel_when_hotcod_is_zero() {
        //Given
        var anyHotcod = 0;
        var anyHozhor = "anyHozhor";
        var anyReshotel = new Reshotel {
            Hotcod = anyHotcod,
            Hozhor = anyHozhor
        };

        //When
        Func<Task> function = async () => await createHotel.Execute(anyReshotel);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid hotel code");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}

