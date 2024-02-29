namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.CancellationPolicyLine;
[TestFixture]
public class CreateCancellationPolicyLineShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateCancellationPolicyLine createCancellationPolicyLine;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createCancellationPolicyLine = new CreateCancellationPolicyLine();
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
            To = new DateTime(2021, 12, 31),
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

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
