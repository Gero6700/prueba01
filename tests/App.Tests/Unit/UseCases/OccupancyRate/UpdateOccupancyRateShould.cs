using Senator.As400.Cloud.Sync.Application.UseCases.OcuppanceRate;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OccupancyRate;
[TestFixture]
public class UpdateOccupancyRateShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateOccupancyRate updateOccupancyRate;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateOccupancyRate = new UpdateOccupancyRate(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_occupancy_rate() {
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
        await updateOccupancyRate.Execute(anyResthaco);

        //Then
        var expectedOccupancyRate = new Infrastructure.Dtos.BookingCenter.OccupancyRate {
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
            .UpdateOccupancyRate(Arg.Is<Infrastructure.Dtos.BookingCenter.OccupancyRate>(x => IsEquivalent(x, expectedOccupancyRate)));
    }

    [Test]
    public async Task do_not_update_occupancy_rate_when_cocod_is_empty() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = string.Empty
        };

        //When
        Func<Task> function = async () => await updateOccupancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
