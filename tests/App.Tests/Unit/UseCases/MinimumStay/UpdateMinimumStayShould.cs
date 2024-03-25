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
        const char anyC7peri = 'S';

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithC7peri(anyC7peri)
            .Build();

        //When
        await updateMinimumStay.Execute(anyConestmi);

        //Then
        var expectedConestmi = new Infrastructure.Dtos.BookingCenter.MinimumStay {
            Code = anyConestmi.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 01, 01),
            Days = anyConestmi.C7dmin,
            StrictPeriod = true,
            ContractClientCode = anyConestmi.ContractClientCode,
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
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
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
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid end date");
    }

    [Test]
    public async Task do_not_update_minimum_stay_when_c7fec2_is_less_than_c7fec1() {
        //Given
        const int anyC7fec1 = 20240102;
        const int anyC7fec2 = 20240101;
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("End date is less than start date");
    }

    [Test]
    public async Task do_not_update_minimum_stay_when_code_is_empty() {
        //Given
        const string anyCode = "";

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithCode(anyCode)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_update_minimum_stay_when_contract_client_code_is_empty() {
        //Given
        const string anyContractClientCode = "";

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithContractClientCode(anyContractClientCode)
            .Build();

        //When
        Func<Task> function = async () => await updateMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Contract client code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
