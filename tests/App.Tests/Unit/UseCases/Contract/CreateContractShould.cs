using System.Net.Mime;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Contract; 

[TestFixture]
public class CreateContractShould {
    private CreateContract createContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createContract = new CreateContract(availabilitySynchronizerApiClient);
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
        const string anyCodmerca = "E";
        const decimal anyCenimi = 3.0m;
        const decimal anyCenima = 12.99m;
        const decimal anyD4desd = 13.0m;
        const decimal anyD4hast = 17.99m;
        const decimal anyCocoag = 0.0m;
        const long anyIdusuario = 123456789012;
                
       
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
            .WithCenima(anyCenima)
            .WithCenimi(anyCenimi)
            .WithD4desd(anyD4desd)
            .WithD4hast(anyD4hast)
            .WithCocoag(anyCocoag)
            .WithIdusuario(anyIdusuario)
            .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Application.Dtos.BookingCenter.Contract {
            Code = string.Concat(anyCohote, anyCocont, anyCofec1, anyCovers),
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = true,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 01, 01),
            DepositType = DepositType.Percent,
            HotelCode = anyCohote,
            CurrencyCode = anyComone.ToString(),
            Market = anyCodmerca
        };
        var expectedContractClient = new Application.Dtos.BookingCenter.ContractClient {
            Code = string.Concat(anyCoagen, anyCosucu, anyCoagcl, anyCosucl),
            MinAgeOfBabies = 0,
            MaxAgeOfBabies = anyCenimi - 0.01m,
            MinAgeOfChildren = anyCenimi,
            MaxAgeChildren = anyCenima,
            MinAgeOfTeenagers = anyD4desd,
            MaxAgeOfTeenagers = anyD4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = (decimal)anyCocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode= expectedContract.Code,
            ClientCode = anyIdusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateContract(Arg.Is<Application.Dtos.BookingCenter.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<Application.Dtos.BookingCenter.ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}