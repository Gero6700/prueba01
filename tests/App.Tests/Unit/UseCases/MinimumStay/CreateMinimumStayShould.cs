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
        const int anyCofec1 = 2024001;
        const char anyC7peri = 'S';

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .WithC7peri(anyC7peri)
            .Build();

        //When
        await createMinimumStay.Execute(anyConestmi);

        //Then
        var expectedConestmi = new Infrastructure.Dtos.BookingCenter.MinimumStay {
            Code = string.Concat(anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers, 
            anyConestmi.C7agen,anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl, anyConestmi.C7Lin),
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
            CreateMinimumStay(Arg.Is<Infrastructure.Dtos.BookingCenter.MinimumStay>(x => IsEquivalent(x, expectedConestmi)));
    }

    [Test]
    public async Task create_minimum_stay_when_c7peri_is_empty() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024001;
        const char anyC7peri = '\0';

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .WithC7peri(anyC7peri)
            .Build();

        //When
        await createMinimumStay.Execute(anyConestmi);

        //Then
        var expectedConestmi = new Infrastructure.Dtos.BookingCenter.MinimumStay {
            Code = string.Concat(anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers, 
                       anyConestmi.C7agen,anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl, anyConestmi.C7Lin),
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 01, 01),
            Days = anyConestmi.C7dmin,
            StrictPeriod = false,
            ContractClientCode = string.Concat(anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers,
                       anyConestmi.C7agen, anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl),
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
        const int anyCofec1 = 2024001;
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
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
        const int anyCofec1 = 2024001;
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid end date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_cofec1_is_invalid() {
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
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid contract start date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7fec1_is_less_than_cofec1() {
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
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Start date is less than contract start date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7fec2_is_less_than_c7fec1() {
        //Given
        const int anyC7fec1 = 20240102;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024001;
        
        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("End date is less than start date");
    }

    [Test]
    public async Task do_not_create_minimum_stay_when_c7hote_is_zero() {
        //Given
        const int anyC7fec1 = 20240101;
        const int anyC7fec2 = 20240101;
        const int anyCofec1 = 2024001;
        const int anyC7hote = 0;

        var anyConestmi = ConestmiBuilder.AConestmiBuilder()
            .WithC7fec1(anyC7fec1)
            .WithC7fec2(anyC7fec2)
            .WithCofec1(anyCofec1)
            .WithC7hote(anyC7hote)
            .Build();

        //When
        Func<Task> function = async () => await createMinimumStay.Execute(anyConestmi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect hotel code");

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
