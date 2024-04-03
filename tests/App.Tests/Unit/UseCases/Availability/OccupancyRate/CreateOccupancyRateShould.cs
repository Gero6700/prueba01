namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.OccupancyRate;

[TestFixture]
public class CreateOccupancyRateShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOccupancyRate createOccupancyRate;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOccupancyRate = new CreateOccupancyRate(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_occupancy_rate() {
        //Given
        const string anyCocod = "anyCocod";
        const int anyCminad = 1;
        const int anyCminat = 2;
        const int anyCminni = 3;
        const int anyCminin = 0;
        const int anyCmaxad = 4;
        const int anyCmaxat = 5;
        const int anyCmaxni = 6;
        const int anyCmaxin = 7;
        const decimal anyCmaxto = 1.10m;
        const decimal anyCminto = 0.10m;

        var anyResthaco = new Resthaco {
            Cocod = anyCocod,
            Cminad = anyCminad,
            Cminat = anyCminat,
            Cminni = anyCminni,
            Cminin = anyCminin,
            Cmaxad = anyCmaxad,
            Cmaxat = anyCmaxat,
            Cmaxni = anyCmaxni,
            Cmaxin = anyCmaxin,
            Cmaxto = anyCmaxto,
            Cminto = anyCminto
        };

        //When
        await createOccupancyRate.Execute(anyResthaco);

        //Then
        var expectedOccupancyRate = new Infrastructure.Dtos.BookingCenter.Availability.OccupancyRate {
            Code = anyCocod,
            MinAdult = anyCminad,
            MinTeen = anyCminat,
            MinChild = anyCminni,
            MinInfant = anyCminin,
            MaxAdult = anyCmaxad,
            MaxTeen = anyCmaxat,
            MaxChild = anyCmaxni,
            MaxScore = anyCmaxto,
            MinScore = anyCminto
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOccupancyRate(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OccupancyRate>(x => IsEquivalent(x, expectedOccupancyRate)));
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cocod_is_empty() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = string.Empty
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cmaxad_is_less_than_cminad() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminad = 2,
            Cmaxad = 1
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max adult is less than min adult");
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cmaxat_is_less_than_cminat() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminat = 2,
            Cmaxat = 1
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max teen is less than min teen");
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cmaxni_is_less_than_cminni() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminni = 2,
            Cmaxni = 1
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max child is less than min child");
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cmaxin_is_less_than_cminin() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminin = 2,
            Cmaxin = 1
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max infant is less than min infant");
    }

    [Test]
    public async Task do_not_create_occupancy_rate_when_cmaxto_is_less_than_cminto() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminto = 2,
            Cmaxto = 1
        };

        //When
        Func<Task> function = async () => await createOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max score is less than min score");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
