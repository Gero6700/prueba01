namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Contract; 

[TestFixture]
public class CreateContractShould {
    private CreateContract createContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createContract = new CreateContract();
    }

    [Test]
    public async Task create_contract() {
        // Given
        const int anyCoagen = 10600;
        const int anyCosucu = 1;
        const int anyCohote = 150;
        const string anyCocont = "01";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024365;
        const int anyCoagcl = 10600;
        const int anyCosucl = 0;
        const int anyComone = 23;
        const int anyCovers = 0;
        //const string anyComerca = "E";
        var anyConcabec = ConcabecBuilder.AnConcabecBuilder()
            .WithCoagen(anyCoagen)
            .WithCosucu(anyCosucu)
            .WithCohote(anyCohote)
            .WithCocont(anyCocont)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCoagcl(anyCoagcl)
            .WithCosucl(anyCosucl)
            .WithComone(anyComone)
            .WithCovers(anyCovers)
            .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Application.Dtos.BookingCenter.Contract {
            Code = anyCohote + anyCocont + anyCofec1 + anyCovers,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = true,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 01, 01),
            DepositType = DepositType.Percent,
            HotelCode = anyCohote,
            CurrencyCode = anyComone.ToString(),
            Market = "E"
        };
        await availabilitySynchronizerApiClient.Received()
            .PushContract(Arg.Is<Application.Dtos.BookingCenter.Contract>(c => IsEquivalent(c, expectedContract)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}