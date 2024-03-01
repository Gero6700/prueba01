using FluentAssertions.Specialized;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.CancellationPolicyLine;
[TestFixture]
public class CreateCancellationPolicyLineShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateCancellationPolicyLine createCancellationPolicyLine;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createCancellationPolicyLine = new CreateCancellationPolicyLine(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_cancellation_policy_line() {
        //Given
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6medi = "";
        const string anyC6ofer = "";
        const string anyC6segu = "";
        const string anyC6bono = "";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)
            .WithC6medi(anyC6medi)
            .WithC6ofer(anyC6ofer)
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = false,
            ApplyIfInsurance = false,
            RefundAsBonus = false,
            ContractClients = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));

    }

    [Test]
    public async Task create_cancellation_policy_line_when_c6medi_is_selected() {
        //Given
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6medi = "S";
        const string anyC6ofer = "";
        const string anyC6segu = "";
        const string anyC6bono = "";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)
            .WithC6medi(anyC6medi)
            .WithC6ofer(anyC6ofer)
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = CancellationPolicyApplicationType.Avarage,
            ApplyInOfferPrice = false,
            ApplyIfInsurance = false,
            RefundAsBonus = false,
            ContractClients = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));

    }

    [Test]
    public async Task create_cancellation_policy_line_when_c6ofer_is_selected() {
        //Given
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6medi = "";
        const string anyC6ofer = "S";
        const string anyC6segu = "";
        const string anyC6bono = "";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)
            .WithC6medi(anyC6medi)
            .WithC6ofer(anyC6ofer)
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = true,
            ApplyIfInsurance = false,
            RefundAsBonus = false,
            ContractClients = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));

    }

    [Test]
    public async Task create_cancellation_policy_line_when_c6segu_is_selected() {
        //Given
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6segu = "S";
        const string anyC6bono = "";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)            
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = anyCongasan.C6medi.ToUpper() == "S" ? CancellationPolicyApplicationType.Avarage : CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = anyCongasan.C6ofer.ToUpper() == "S" ? true : false,
            ApplyIfInsurance = true,
            RefundAsBonus = false,
            ContractClients = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));

    }

    [Test]
    public async Task create_cancellation_policy_line_when_c6bono_is_selected() {
        //Given
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6medi = "";
        const string anyC6ofer = "";
        const string anyC6segu = "";
        const string anyC6bono = "S";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)
            .WithC6medi(anyC6medi)
            .WithC6ofer(anyC6ofer)
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = false,
            ApplyIfInsurance = false,
            RefundAsBonus = true,
            ContractClients = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));

    }

    [Test]
    public async Task create_cancellation_policy_line_when_origin_type_is_offer() {
        //Given
        const OriginType anyOriginType = OriginType.Offer;
        const int anyC6fec1 = 20240101;
        const int anyC6fec2 = 20241231;
        const string anyC6medi = "";
        const string anyC6ofer = "";
        const string anyC6segu = "";
        const string anyC6bono = "";

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithOriginType(anyOriginType)
            .WithC6fec1(anyC6fec1)
            .WithC6fec2(anyC6fec2)
            .WithC6medi(anyC6medi)
            .WithC6ofer(anyC6ofer)
            .WithC6segu(anyC6segu)
            .WithC6bono(anyC6bono)
            .Build();

        //When
        await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        var expectedCancellationPolicyLine = new Infrastructure.Dtos.BookingCenter.CancellationPolicyLine {
            Code = anyCongasan.Code,
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 12, 31),
            ReleaseDays = anyCongasan.C6gcdi,
            ReleaseHours = anyCongasan.C6gcho,
            PenaltyNights = anyCongasan.C6gcno,
            PenaltyPercent = anyCongasan.C6gcpo,
            PenaltyAmount = anyCongasan.C6gcim,
            ApplicationMargin = anyCongasan.C6marg,
            ApplicationType = CancellationPolicyApplicationType.FirstNight,
            ApplyInOfferPrice = false,
            ApplyIfInsurance = false,
            RefundAsBonus = false,
            OffersAndSuplements = new List<string>() { anyCongasan.OriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateCancellationPolicyLine(Arg.Is<Infrastructure.Dtos.BookingCenter.CancellationPolicyLine>(x => IsEquivalent(x, expectedCancellationPolicyLine)));
    }

    [Test]
    public async Task do_not_create_cancellation_policy_line_when_c6fec1_is_invalid() {
        //Given
        const int anyC6fec1 = 2024;

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithC6fec1(anyC6fec1)
            .Build();

        //When
        Func<Task> function = async () => await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid from date");
    }

    [Test]
    public async Task do_not_create_cancellation_policy_line_when_c6fec2_is_invalid() {
        //Given
        const int anyC6fec2 = 2024;

        var anyCongasan = CongasanBuilder.ACongasanBuilder()
            .WithC6fec2(anyC6fec2)
            .Build();

        //When
        Func<Task> function = async () => await createCancellationPolicyLine.Execute(anyCongasan);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid to date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
