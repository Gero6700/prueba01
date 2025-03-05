namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Contract;

[TestFixture]
public class CreateContractShould {
    private CreateContractHeader createContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createContract = new CreateContractHeader(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_contract() {
        // Given
        const int anyCohote = 150;
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const string anyCodesc = "CONTRACT 01 2024";
        const string anyDinom2 = "EUR";
        const string anyCodmerca = "E";
        const int anyCoftop = 20240601;
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
        const string anyCobaco = "B";

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithCohote(anyCohote)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCodesc(anyCodesc)
            .WithDinom2(anyDinom2)
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
            .WithCobaco(anyCobaco)
            .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.ContractHeaderDto {
            Code = anyConcabec.ContractCode,
            Description = anyCodesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = true,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 1),
            DepositAmount = anyCodpto,
            DepositType = DepositType.Percent,
            HotelCode = anyCohote.ToString(),
            CurrencyIsoCode = anyDinom2,
            MarketCode = anyCodmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = 0,
            MaxAgeOfBabies = anyCeinma,
            MinAgeOfChildren = anyCenimi,
            MaxAgeChildren = anyCenima,
            MinAgeOfTeenagers = anyD4desd,
            MaxAgeOfTeenagers = anyD4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyCocoag,
            ComissionType = IncomeType.Net,
            ContractCode = expectedContract.Code,
            ClientCode = anyIdusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    [Test]
    public async Task create_contract_when_coftop_is_zero() {
        // Given
        const int anyCoftop = 0;
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCoftop(anyCoftop)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.Contract {
            Code = anyConcabec.ContractCode,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = string.Equals(anyConcabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = null,
            DepositAmount = anyConcabec.Codpto,
            DepositType = anyConcabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = anyConcabec.Cohote.ToString(),
            CurrencyIsoCode = anyConcabec.Dinom2,
            MarketCode = anyConcabec.Codmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = anyConcabec.Ceinmi,
            MaxAgeOfBabies = anyConcabec.Ceinma,
            MinAgeOfChildren = anyConcabec.Cenimi,
            MaxAgeChildren = anyConcabec.Cenima,
            MinAgeOfTeenagers = anyConcabec.D4desd,
            MaxAgeOfTeenagers = anyConcabec.D4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyConcabec.Cocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyConcabec.Idusuario.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    [Test]
    public async Task create_contract_when_coiva_is_not_included() {
        // Given
        const string anyCoiva = "E";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        // When
        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCoiva(anyCoiva)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.Contract {
            Code = anyConcabec.ContractCode,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = false,
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 1),
            DepositAmount = anyConcabec.Codpto,
            DepositType = anyConcabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = anyConcabec.Cohote.ToString(),
            CurrencyIsoCode = anyConcabec.Dinom2,
            MarketCode = anyConcabec.Codmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = anyConcabec.Ceinmi,
            MaxAgeOfBabies = anyConcabec.Ceinma,
            MinAgeOfChildren = anyConcabec.Cenimi,
            MaxAgeChildren = anyConcabec.Cenima,
            MinAgeOfTeenagers = anyConcabec.D4desd,
            MaxAgeOfTeenagers = anyConcabec.D4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyConcabec.Cocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyConcabec.Idusuario.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
           .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));

    }

    [Test]
    public async Task create_contract_when_cofode_is_empty() {
        // Given
        const string anyCofode = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofode(anyCofode)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.Contract {
            Code = anyConcabec.ContractCode,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = string.Equals(anyConcabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 1),
            DepositAmount = anyConcabec.Codpto,
            DepositType = DepositType.Fixed,
            HotelCode = anyConcabec.Cohote.ToString(),
            CurrencyIsoCode = anyConcabec.Dinom2,
            MarketCode = anyConcabec.Codmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = anyConcabec.Ceinmi,
            MaxAgeOfBabies = anyConcabec.Ceinma,
            MinAgeOfChildren = anyConcabec.Cenimi,
            MaxAgeChildren = anyConcabec.Cenima,
            MinAgeOfTeenagers = anyConcabec.D4desd,
            MaxAgeOfTeenagers = anyConcabec.D4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyConcabec.Cocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyConcabec.Idusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
           .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    [Test]
    public async Task create_contract_when_cofext_is_zero() {
        // Given
        const int anyCofext = 0;
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofext(anyCofext)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.Contract {
            Code = anyConcabec.ContractCode,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = string.Equals(anyConcabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 1),
            DepositAmount = anyConcabec.Codpto,
            DepositType = anyConcabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = anyConcabec.Cohote.ToString(),
            CurrencyIsoCode = anyConcabec.Dinom2,
            MarketCode = anyConcabec.Codmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = anyConcabec.Ceinmi,
            MaxAgeOfBabies = anyConcabec.Ceinma,
            MinAgeOfChildren = anyConcabec.Cenimi,
            MaxAgeChildren = anyConcabec.Cenima,
            MinAgeOfTeenagers = anyConcabec.D4desd,
            MaxAgeOfTeenagers = anyConcabec.D4hast,
            ExpiredDate = null,
            Comission = anyConcabec.Cocoag,
            ComissionType = anyConcabec.Cobaco == "B" ? IncomeType.Net : IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyConcabec.Idusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
           .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));
    }

    [Test]
    public async Task create_contract_when_cobaco_is_empty() {
        // Given
        const string anyCobaco = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCobaco(anyCobaco)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedContract = new Infrastructure.Dtos.BookingCenter.Availability.Contract {
            Code = anyConcabec.ContractCode,
            Description = anyConcabec.Codesc,
            ValidDateFrom = new DateTime(2024, 01, 01),
            ValidDateTo = new DateTime(2024, 12, 31),
            TaxIncluded = string.Equals(anyConcabec.Coiva, "I"),
            TypeOfAgeOrdering = TypeOfAgeOrdering.Asc,
            DepositDate = new DateTime(2024, 6, 1),
            DepositAmount = anyConcabec.Codpto,
            DepositType = anyConcabec.Cofode == "%" ? DepositType.Percent : DepositType.Fixed,
            HotelCode = anyConcabec.Cohote.ToString(),
            CurrencyIsoCode = anyConcabec.Dinom2,
            MarketCode = anyConcabec.Codmerca
        };
        var expectedContractClient = new ContractClient {
            Code = anyConcabec.ContractClientCode,
            MinAgeOfBabies = anyConcabec.Ceinmi,
            MaxAgeOfBabies = anyConcabec.Ceinma,
            MinAgeOfChildren = anyConcabec.Cenimi,
            MaxAgeChildren = anyConcabec.Cenima,
            MinAgeOfTeenagers = anyConcabec.D4desd,
            MaxAgeOfTeenagers = anyConcabec.D4hast,
            ExpiredDate = new DateTime(2024, 12, 31),
            Comission = anyConcabec.Cocoag,
            ComissionType = IncomeType.Pvp,
            ContractCode = expectedContract.Code,
            ClientCode = anyConcabec.Idusuario.ToString()
        };
        await availabilitySynchronizerApiClient.Received()
           .CreateContract(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Contract>(c => IsEquivalent(c, expectedContract)));
        await availabilitySynchronizerApiClient.Received()
            .CreateContractClient(Arg.Is<ContractClient>(c => IsEquivalent(c, expectedContractClient)));

    }

    [Test]
    public async Task do_not_create_contract_when_cofec1_is_invalid() {
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
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid start date");

    }

    [Test]
    public async Task do_not_create_contract_when_cofec2_is_invalid() {
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
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

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
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid extinction date");

    }

    [Test]
    public async Task do_not_create_contract_when_end_date_is_less_than_start_date() {
        // Given
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2023365;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("End date is less than start date");

    }

    [Test]
    public async Task do_not_create_contract_when_idusuario_is_zero() {
        // Given
        const long anyIdusuario = 0;
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithIdusuario(anyIdusuario)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect user code");

    }

    [Test]
    public async Task do_not_create_contract_when_cohote_is_zero() {
        // Given
        const int anyCohote = 0;
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCohote(anyCohote)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect hotel code");

    }

    [Test]
    public async Task do_not_create_contract_when_market_is_empty() {
        // Given
        const string anyCodmerca = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
           .WithCodmerca(anyCodmerca)
           .WithCofec1(anyCofec1)
           .WithCofec2(anyCofec2)
           .WithCofext(anyCofext)
           .WithCoftop(anyCoftop)
           .Build();

        // When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect market code");

    }

    [Test]
    public async Task do_not_create_contract_when_dinom2_is_invalid() {
        //Given
        const string anyDinom2 = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithDinom2(anyDinom2)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCofext(anyCofext)
            .WithCoftop(anyCoftop)
            .Build();

        //When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid currency iso code");

    }

    [Test]
    public async Task do_not_create_contract_when_contract_code_is_empty() {
        //Given
        const string anyContracCode = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithContractCode(anyContracCode)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCofext(anyCofext)
            .WithCoftop(anyCoftop)
            .Build();

        //When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Contract code is required");

    }

    [Test]
    public async Task do_not_create_contract_when_contract_client_code_is_empty() {
        //Given
        const string anyContractClientCode = "";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024366;
        const int anyCofext = 20241231;
        const int anyCoftop = 20240601;

        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithContractClientCode(anyContractClientCode)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCofext(anyCofext)
            .WithCoftop(anyCoftop)
            .Build();

        //When
        Func<Task> function = async () => await createContract.Execute(anyConcabec);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Contract client code is required");

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}