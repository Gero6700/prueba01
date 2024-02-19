namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.MinimumStay;

[TestFixture]
public class CreateMinimumstayShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateMinimumStay createMinimumStay;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createMinimumStay = new CreateMinimumStay();
    }

    [Test]
    public async Task create_minimun_stay() {
        //Given
        const decimal anyC7fec1 = 20240101;
        const decimal anyC7fec2 = 20240101;
        const decimal anyCofec1 = 20240101;
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
            Code = string.Concat(anyConestmi.C7agen,anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl, 
            anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers, anyConestmi.C7Lin),
            From = new DateTime(2024, 01, 01),
            To = new DateTime(2024, 01, 01),
            Days = anyConestmi.C7dmin,
            StrictPeriod = true,
            ContractClientCode = string.Concat(anyConestmi.C7agen, anyConestmi.C7sucu, anyConestmi.C7agcl, anyConestmi.C7sucl,
            anyConestmi.C7hote, anyConestmi.C7cont, anyCofec1, anyConestmi.C7vers),
            RoomCode = anyConestmi.C7thab,
            RegimeCode = anyConestmi.C7regi
        };

        await availabilitySynchronizerApiClient.Received().
            CreateMinimumStay(Arg.Is<Infrastructure.Dtos.BookingCenter.MinimumStay>(x => IsEquivalent(x, expectedConestmi)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
