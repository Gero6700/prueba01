using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplement;

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
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] {0.0m, 0.0m, 0.0m, 0.0m}; //Descuentos adulto/estancia
        var anyOfdas = new[] {0.0m, 0.0m, 0.0m, 0.0m}; //Descuentos adulto/regimen
        var anyOfdne = new[] {0.0m, 0.0m, 0.0m, 0.0m}; //Descuentos niño/estancia
        var anyOfdns = new[] {0.0m, 0.0m, 0.0m, 0.0m}; //Descuentos niño/servicio
        var anyOfthab = new[] {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}; //Tipos de habitacion
        var anyOftser = new[] {"", "", "", "", ""}; //Tipos de servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Fixed,
            DepositBeforeDate = new DateTime(2024, 06, 04),
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = false,
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };  
        
        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offtop_is_zero() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofopci_is_s() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = OfferSupplementType.Offer,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = true,
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offode_is_percent() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofties_is_period() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = StayType.Period,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofties_is_stay() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = StayType.Stay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofadni_is_adult() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = PaymentType.Percent,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = PaxType.Adult,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofadni_is_child() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
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
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = PaxType.Child,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  new DateTime(2024, 03, 01),
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofgrbd_is_zero() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 20240305;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
                    StayType = anyConofege.Ofties.ToUpper() == "P" ? StayType.Period : anyConofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = anyConofege.Ofadni.ToUpper() == "A" ? PaxType.Adult :  anyConofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = anyConofege.Ofdiae,
                    MaxStayDays = anyConofege.Ofdieh,
                    MinReleaseDays = anyConofege.Offred,
                    MaxReleaseDays = anyConofege.Offres,
                    BookingWindowFrom =  DateTime.MinValue,
                    BookingWindowTo =  new DateTime(2024, 03, 05),
                    OccupancyRateCod = anyConofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofgrbh_is_zero() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofthab_is_not_empty() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofthab2_is_empty() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftser_is_not_empty() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftse2_is_empty() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = " ";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOftser(anyOftser)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiae - anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofdfac_is_not_empty() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfdfac = "R";
        const string anyOffore = "";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio
        
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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_p() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "P";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.P,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_x() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "X";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.X,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offore_is_u() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffore = "U";
        const string anyOffors = "";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = ApplyStayPriceType.U,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_p() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "P";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.P,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_x() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "X";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.X,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_offors_is_u() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOffors = "U";
        const string anyOftidt = "";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

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
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = ApplyStayPriceType.U,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_oftidt_is_c() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOftidt = "C";
        const string anyOfsobr = "";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOftidt(anyOftidt)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = PaymentType.Fixed,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofsobr_is_b() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfsobr = "B";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = anyConofege.Oftidt.ToUpper() == "C" ? PaymentType.Fixed : PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Net,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofsobr_is_c() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfsobr = "C";
        const string anyOfapli = "";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfsobr(anyOfsobr)
            .WithOfapli(anyOfapli)
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = anyConofege.Oftidt.ToUpper() == "C" ? PaymentType.Fixed : PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Commission,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    [Test]
    public async Task create_offer_and_supplement_when_ofapli_is_e() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 0;
        const int anyOfgrbd = 0;
        const int anyOfgrbh = 0;
        const string anyOfapli = "E";
        const string anyO4tipa = "ADULT1";
        const string anyO4tdto = "";
        var anyOfdae = new[] { 10.0m, 0.0m, 30.5m, 0.0m }; //Descuentos adulto/estancia
        var anyOfdas = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos adulto/regimen
        var anyOfdne = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/estancia
        var anyOfdns = new[] { 0.0m, 0.0m, 0.0m, 0.0m }; //Descuentos niño/servicio

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
            .WithOffec(anyOffec)
            .WithOffec2(anyOffec2)
            .WithOfftop(anyOfftop)
            .WithOfgrbd(anyOfgrbd)
            .WithOfgrbh(anyOfgrbh)
            .WithOfapli(anyOfapli)
            .WithO4tipa(anyO4tipa)
            .WithO4tdto(anyO4tdto)
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .Build();

        //When
        await createOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = null,
            ModificationCostsAmount = anyConofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = anyConofege.Ofopci.ToUpper() == "S",
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
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = anyConofege.Ofdfac.Trim() == "" ? anyConofege.Ofdiae - anyConofege.Ofdiaf : anyConofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = anyConofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = anyConofege.Oftsef,
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = anyConofege.Oftidt.ToUpper() == "C" ? PaymentType.Fixed : PaymentType.Percent,
                    DiscountTarget = anyConofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : anyConofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.Stay,
                    Paxes = []
                }
            ]
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
