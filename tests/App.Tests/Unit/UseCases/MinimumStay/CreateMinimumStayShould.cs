namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.MinimumStay;

[TestFixture]
public class CreateMinimumStayShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMinimumStay createMinimumStay;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMinimumStay = new CreateMinimumStay(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_minimun_stay() {
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
        await createMinimumStay.Execute(anyConestmi);

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
            CreateMinimumStay(Arg.Is<Infrastructure.Dtos.BookingCenter.MinimumStay>(x => IsEquivalent(x, expectedConestmi)));
    }

    [Test]
    public async Task create_minimum_stay_when_c7peri_is_empty() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const char anyC7peri = '\0';

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithC7peri(anyC7peri)
            .Build();

        //When
        await createMinimumStay.Execute(anyConestmi);

        //Then
        var expectedConestmi = new Infrastructure.Dtos.BookingCenter.MinimumStay {
            Code = anyConestmi.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 01, 01),
            Days = anyConestmi.C7dmin,
            StrictPeriod = false,
            ContractClientCode = anyConestmi.ContractClientCode,
            RoomCode = anyConestmi.C7thab,
            RegimeCode = anyConestmi.C7regi
        };

        await availabilitySynchronizerApiClient.Received().
            CreateMinimumStay(Arg.Is<Infrastructure.Dtos.BookingCenter.MinimumStay>(x => IsEquivalent(x, expectedConestmi)));

    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7fec1_is_invalid() {
        //Given
        const int anyC7fec1 = 20240132;
        const int anyC7fec2 = 20240101;
                
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid start date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7fec2_is_invalid() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240132;
               
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid end date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7fec2_is_less_than_c7fec1() {
        //Given
        const int anyC7fec1 = 20240102;
        const int anyC7fec2 = 20240101;
                
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("End date is less than start date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_code_is_empty() {
        //Given
        const string anyCode = "";

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithCode(anyCode)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_contract_client_code_is_empty() {
        //Given
        const string anyContractClientCode = "";

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithContractClientCode(anyContractClientCode)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Contract client code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
