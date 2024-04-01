namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OcuppancyRate;

[TestFixture]
public class CreateOcuppancyRateShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOcuppancyRate createOcuppancyRate;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOcuppancyRate = new CreateOcuppancyRate(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_ocuppancy_rate() {
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
        await createOcuppancyRate.Execute(anyResthaco);

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
            .CreateOcuppancyRate(Arg.Is<Infrastructure.Dtos.BookingCenter.OcuppancyRate>(x => IsEquivalent(x, expectedOcuppancyRate)));
    }

    [Test]
    public async Task do_not_create_ocuppancy_rate_when_cocod_is_empty() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = string.Empty
        };

        //When
        Func<Task> function = async () => await createOcuppancyRate.Execute(anyResthaco);     

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_create_ocuppancy_rate_when_cmaxad_is_less_than_cminad() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminad = 2,
            Cmaxad = 1
        };

        //When
        Func<Task> function = async () => await createOcuppancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max adult is less than min adult");
    }

    [Test]
    public async Task do_not_create_ocuppancy_rate_when_cmaxat_is_less_than_cminat() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminat = 2,
            Cmaxat = 1
        };

        //When
        Func<Task> function = async () => await createOcuppancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max teen is less than min teen");
    }

    [Test]
    public async Task do_not_create_ocuppancy_rate_when_cmaxni_is_less_than_cminni() {
        //Given
        var anyResthaco = new Resthaco {
            Cocod = "anyCocod",
            Cminni = 2,
            Cmaxni = 1
        };

        //When
        Func<Task> function = async () => await createOcuppancyRate.Execute(anyResthaco);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max child is less than min child");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
