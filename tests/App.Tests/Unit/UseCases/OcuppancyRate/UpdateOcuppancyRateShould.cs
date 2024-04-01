namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OcuppancyRate;
[TestFixture]
public class UpdateOcuppancyRateShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateOcuppancyRate updateOcuppancyRate;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateOcuppancyRate = new UpdateOcuppancyRate(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_ocuppancy_rate() {
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
        await updateOcuppancyRate.Execute(anyResthaco);

        //Then
        var expectedOcuppancyRate = new Infrastructure.Dtos.BookingCenter.OcuppancyRate {
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
            .UpdateOcuppancyRate(Arg.Is<Infrastructure.Dtos.BookingCenter.OcuppancyRate>(x => IsEquivalent(x, expectedOcuppancyRate)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
