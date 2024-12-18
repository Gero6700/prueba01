using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.OfferAndSupplement;

[TestFixture]
public class CreateOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateOfferAndSupplement createOfferAndSupplement;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createOfferAndSupplement = new CreateOfferAndSupplement(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_offer_and_supplement() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOfopci = "";
        const string anyOffode = "";
        const int anyOfftop = 240604;
        const string anyOfTies = "";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfopci(anyOfopci)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = anyConofege.Ofpri == 0 ? null : anyConofege.Ofpri,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Ofdpto == 0 ? null : anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = new DateTime(2024, 06, 04),
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition = new OfferAndSupplementCondition {
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu == 0 ? null : anyConofege.Ofcocu.ToString(),
                    OnlyApplyIfRecordDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    OnlyApplyIfStayDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    WeekDaysApplicationMode = WeekDaysApplicationType.Always, //TODO: Pendiente de Jose
                    Rooms = [],
                    Regimes = []
                },
            Configuration = new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" && anyConofege.Ofdiaf > 0 ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf.Trim() == "" ? null : anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef.Trim() == "" ? null : anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_contract_client_code_is_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOfopci = "";
        const string anyOffode = "";
        const int anyOfftop = 240604;
        const string anyOfTies = "";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyContractClientCode = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfopci(anyOfopci)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithContractClientCode(anyContractClientCode)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = [],
            Type = OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Fixed,
            DepositBeforeDate = new DateTime(2024, 06, 04),
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offtop_is_zero() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOfopci = "";
        const string anyOffode = "";
        const int anyOfftop = 0;
        const string anyOfTies = "";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfopci(anyOfopci)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofopci_is_s() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOfopci = "S";
        const string anyOffode = "";
        const int anyOfftop = 0;
        const string anyOfTies = "";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfopci(anyOfopci)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = OfferSupplementType.Offer,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offode_is_percent() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOffode = "%";
        const int anyOfftop = 0;
        const string anyOfTies = "";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofties_is_period() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOffode = "%";
        const int anyOfftop = 0;
        const string anyOfTies = "P";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.Period,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofties_is_stay() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOffode = "%";
        const int anyOfftop = 0;
        const string anyOfTies = "E";
        const string anyOfadni = "";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfties(anyOfTies)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = StayType.Stay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofadni_is_adult() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const string anyOffode = "%";
        const int anyOfftop = 0;
        const string anyOfadni = "A";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOffode(anyOffode)
            .WithOfftop(anyOfftop)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = TypeOfPayment.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = PaxType.Adult,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofadni_is_child() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const string anyOfadni = "N";
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfadni(anyOfadni)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = PaxType.Child,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofgrbd_is_zero() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofgrbh_is_zero() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofthab_is_not_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [.. anyOfthab],
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofthab2_is_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOfthab = new[] { "A", "", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" }; //Tipos de habitacion
        var anyOftser = new[] { "", "", "", "", "" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyOfthab.Where(value => value != "").ToList(),
                    Regimes = []
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftser_is_not_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOftser = new[] { "A", "B", "C", "D", "E" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = [.. anyOftser]
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftse2_is_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        var anyOftser = new[] { "A", "", "C", "D", "E" }; //Tipos de servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = { "A", "C", "D", "E" }
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofdfac_is_not_empty() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = "R";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfdfac(anyOfdfac)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_p() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "P";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.P,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_x() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "X";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.X,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_u() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "U";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffore(anyOffore)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.U,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_p() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "P";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.P,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_x() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "X";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.X,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_u() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "U";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOffors(anyOffors)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.U,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Percent,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftidt_is_c() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOftidt = "C";
        const string anyOfsobr = "";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = TypeOfPayment.Fixed,
                    Target = DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofsobr_is_b() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfsobr = "B";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = anyConofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed : TypeOfPayment.Percent,
                    Target = DiscountTargetType.Net,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofsobr_is_c() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfsobr = "C";
        const string anyOfapli = "";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = anyConofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed : TypeOfPayment.Percent,
                    Target = DiscountTargetType.Commission,
                    Scope = DiscountScopeType.All
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofapli_is_e() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfapli = "E";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = anyConofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed : TypeOfPayment.Percent,
                    Target = anyConofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : anyConofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.Stay
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofapli_is_s() {
        //Given
        const int anyOffec = 20240101;
        const int anyOffec2 = 20240102;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfapli = "S";

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfapli(anyOfapli)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement {
            Code = anyConofege.Code,
            ContractClients = new List<string> { anyConofege.ContractClientCode },
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Condition =
                new OfferAndSupplementCondition {
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom = DateTime.MinValue,
                    BookingWindowTo = DateTime.MinValue,
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = anyConofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = anyConofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration =
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    Amount = anyConofege.Ofdtos,
                    AmountType = anyConofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed : TypeOfPayment.Percent,
                    Target = anyConofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : anyConofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    Scope = DiscountScopeType.Regime
                }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_offec_is_invalid() {
        //Given
        const int anyOffec = 2024;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply from date");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_offec2_is_invalid() {
        //Given
        const int anyOffec2 = 2024;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec2(anyOffec2)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply to date");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_offec2_is_less_than_offec() {
        //Given
        const int anyOffec = 20240102;
        const int anyOffec2 = 20240101;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Apply to date is less than apply from date");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_offtop_is_invalid() {
        //Given
        const int anyOfftop = 2406004;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOfftop(anyOfftop)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid deposit date");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_code_is_empty() {
        //Given
        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithCode("")
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_ofdieh_is_less_than_ofdiae_and_ofdieh_is_greater_than_zero() {
        //Given
        const int anyOfdieh = 1;
        const int anyOfdiae = 2;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOfdieh(anyOfdieh)
            .WithOfdiae(anyOfdiae)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max stay days is less than min stay days");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_offres_is_less_than_offred_and_offres_is_greater_than_zero() {
        //Given
        const int anyOffred = 2;
        const int anyOffres = 1;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffred(anyOffred)
            .WithOffres(anyOffres)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Max release days is less than min release days");
    }

    [Test]
    public async Task do_not_create_offer_and_supplement_when_ofgrbh_is_less_than_ofgrbd_and_are_not_zero() {
        //Given
        const int anyOfgrbd = 20240130;
        const int anyOfgrbh = 20240129;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .Build();

        //When
        Func<Task> function = async () => await createOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Booking window to date is less than booking window from date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
