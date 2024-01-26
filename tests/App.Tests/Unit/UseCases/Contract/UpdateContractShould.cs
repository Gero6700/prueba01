using Senator.As400.Cloud.Sync.Application.UseCases.Contract;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Contract;

[TestFixture]
public class UpdateContractShould {
    private UpdateContract updateContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateContract = new UpdateContract(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_contract() {
        // Given
        const int anyCoagen = 10600;
        const int anyCosucu = 1;
        const int anyCohote = 150;
        const string anyCocont = "01";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const string anyCodesc = "CONTRACT 01 2024";
        const int anyCoagcl = 10600;
        const int anyCosucl = 0;
        const int anyComone = 23;
        const int anyCovers = 0;
        const string anyCodmerca = "E";
        const int anyCoftop = 20240605;
        const decimal anyCodpto = 0.00m;
        const string anyCofode = "%";
        const string anyCoiva = "I";
        const decimal anyCeinma = 2.99m;
        const decimal anyCenimi = 3.00m;
        const decimal anyCenima = 12.99m;
        const decimal anyD4desd = 13.00m;
        const decimal anyD4hast = 17.99m;
        const decimal anyCocoag = 0.0m;
        const long anyIdusuario = 123456789012;
        const int anyCofext = 20241231;


        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithCoagen(anyCoagen)
            .WithCosucu(anyCosucu)
            .WithCohote(anyCohote)
            .WithCocont(anyCocont)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCodesc(anyCodesc)
            .WithCoagcl(anyCoagcl)
            .WithCosucl(anyCosucl)
            .WithComone(anyComone)
            .WithCovers(anyCovers)
            .WithCodmerca(anyCodmerca)
            .WithCoftop(anyCoftop)
            .WithCodpto(anyCodpto)
            .WithCofode(anyCofode)
            .WithCoiva(anyCoiva)
            .WithCeinma(anyCeinma)
            .WithCenima(anyCenima)
            .WithCenimi(anyCenimi)
            .WithD4desd(anyD4desd)
            .WithD4hast(anyD4hast)
            .WithCocoag(anyCocoag)
            .WithIdusuario(anyIdusuario)
            .WithCofext(anyCofext)
            .Build();

        // When
        await updateContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Contract {
            Code = string.Concat(anyCohote, anyCocont, anyCofec1, anyCovers),
            Description = anyCodesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = true,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 5),
            DepositAmount = anyCodpto,
            DepositType = DepositType.Percent,
            HotelCode = anyCohote,
            CurrencyCode = anyComone.ToString(),
            Market = anyCodmerca
        };
        var expectedContractClient = new ContractClient {
            Code = string.Concat(anyCoagen, anyCosucu, anyCoagcl, anyCosucl),
            MinAgeOfBabies = 0,
            MaxAgeOfBabies = anyCeinma,
            MinAgeOfChildren = anyCenimi,
            MaxAgeChildren = anyCenima,
            MinAgeOfTeenagers = anyD4desd,
            MaxAgeOfTeenagers = anyD4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyCocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyIdusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .UpdateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    [Test]
    public async Task do_not_update_contract_when_cofec1_is_invalid() {
        // Given
        const int anyCofec1 = 500;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await updateContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid start date");

    }

    [Test]
    public async Task do_not_update_contract_when_cofec2_is_invalid() {
        // Given
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 500;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await updateContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid end date");

    }

    [Test]
    public async Task do_not_create_contract_when_cofext_is_invalid() {
        // Given
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 500;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await updateContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid extinction date");

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}