using Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.MinimumStay;

[TestFixture]
public class UpdateMinimumStayShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateMinimumStay updateMinimumStay;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateMinimumStay = new UpdateMinimumStay(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_minimum_stay() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024001;
        const char anyC7peri = 'S';

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .WithC7peri(anyC7peri)
            .Build();

        //When
        await updateMinimumStay.Execute(anyConestmi);

        //Then
        var expectedConestmi = new Infrastructure.Dtos.BookingCenter.MinimumStay {
            Code = string.Concat(anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers,
            anyConestmi.C7agen, anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl, anyConestmi.C7Lin),
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 01, 01),
            Days = anyConestmi.C7dmin,
            StrictPeriod = true,
            ContractClientCode = string.Concat(anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers,
            anyConestmi.C7agen, anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl),
            RoomCode = anyConestmi.C7thab,
            RegimeCode = anyConestmi.C7regi
        };

        await availabilitySynchronizerApiClient.Received().
            UpdateMinimumStay(Arg.Is<Infrastructure.Dtos.BookingCenter.MinimumStay>(x => IsEquivalent(x, expectedConestmi)));

    }

    [Test]
    public async Task do_not_update_minimum_stay_when_c7fec1_is_invalid() {
        //Given
        const int anyC7fec1 = 0;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024001;

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid start date");

    }

    [Test]
    public async Task do_not_update_minimum_stay_when_c7fec2_is_invalid() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 0;
        const int anyCofec1 = 2024001;

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid end date");
    }

    [Test]
    public async Task do_not_update_minimum_stay_when_cofec1_is_invalid() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 0;

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid contract start date");
    }

    [Test]
    public async Task do_not_update_minimum_stay_when_c7fec1_is_less_than_cofec1() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024002;

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Start date is less than contract start date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
