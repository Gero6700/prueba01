using Senator.As400.Cloud.Sync.Application.UseCases.Contract;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Extra;

[TestFixture]
public class CreateExtraShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateExtra createExtra;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createExtra = new CreateExtra(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_extra() {
        //Given
        const string anyCode = "anyCode";
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const int anyC5died = 1;
        const int anyC5dihd = 2;
        const string anyC5Sele = "S";
        const int anyC5unid = 1;
        const int anyC5inta = 1;
        const string anyC5foun = "U";
        const decimal anyC5prec = 5.50m;
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const bool anyCogc = false;
        const int anyC5cocu = 1;
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";
        const string anyOffoe = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5died(anyC5died)
            .WithC5dieh(anyC5dihd)
            .WithC5Sele(anyC5Sele)
            .WithC5unid(anyC5unid)
            .WithC5inta(anyC5inta)
            .WithC5foun(anyC5foun)
            .WithC5prec(anyC5prec)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithCogc(anyCogc)
            .WithC5cocu(anyC5cocu)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOffoe(anyOffoe)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyCode,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyC5died,
            StayTo = anyC5dihd,
            Mandatory = anyC5Sele != "S",
            Quantity = anyC5unid,
            ByDay = anyC5inta,
            ApplyBy = ApplyStayPriceType.U,
            Price = anyC5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyCogc,
            OccupancyRateCod = anyC5cocu.ToString(),
            Paxes = new List<ExtraPax>(),
            Rooms = new List<string>(),
            Regimes = new List<string>(),
            ContractClients = new List<string>() {anyOriginCode},
            OfferAndSuplements = new List<ExtraOfferAndSuplement>()
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
    }

    [Test]
    public async Task create_extra_when_origintype_is_offer() {
        //Given
        //Given
        const string anyCode = "anyCode";
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Offer;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";
        const string anyOffoe = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOffoe(anyOffoe)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyCode,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            OfferAndSuplements = new List<ExtraOfferAndSuplement> {
                new ExtraOfferAndSuplement {
                    OfferAndSuplementCode = anyOriginCode,
                    ApplyStayPriceType = ApplyStayPriceType.D
                }
            }
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
    }

    [Test]
    public async Task create_extra_when_origintype_is_offer_and_offoe_is_p() {
        //Given
        //Given
        const string anyCode = "anyCode";
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Offer;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";
        const string anyOffoe = "P";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOffoe(anyOffoe)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyCode,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            OfferAndSuplements = new List<ExtraOfferAndSuplement> {
                new ExtraOfferAndSuplement {
                    OfferAndSuplementCode = anyOriginCode,
                    ApplyStayPriceType = ApplyStayPriceType.P
                }
            }
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
    }

    [Test]
    public async Task create_extra_when_origintype_is_offer_and_offoe_is_u() {
        //Given
        //Given
        const string anyCode = "anyCode";
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Offer;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";
        const string anyOffoe = "U";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOffoe(anyOffoe)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyCode,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            OfferAndSuplements = new List<ExtraOfferAndSuplement> {
                new ExtraOfferAndSuplement {
                    OfferAndSuplementCode = anyOriginCode,
                    ApplyStayPriceType = ApplyStayPriceType.U
                }
            }
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
    }

    [Test]
    public async Task create_extra_when_origintype_is_offer_and_offoe_is_x() {
        //Given
        //Given
        const string anyCode = "anyCode";
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Offer;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";
        const string anyOffoe = "X";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOffoe(anyOffoe)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyCode,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            OfferAndSuplements = new List<ExtraOfferAndSuplement> {
                new ExtraOfferAndSuplement {
                    OfferAndSuplementCode = anyOriginCode,
                    ApplyStayPriceType = ApplyStayPriceType.X
                }
            }
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
    }

    [Test]
    public async Task create_extra_when_c5dtn_is_not_zero() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 10.0m;
        const decimal anyC5dtn2 = 20.0m;
        const decimal anyC5dtn3 = 30.0m;
        const decimal anyC5dtn4 = 40.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //when
        await createExtra.Execute(anyConextra);

        //then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            Paxes = new List<ExtraPax> {
                new ExtraPax {
                    PaxOrder = 1,
                    PaxType = PaxType.Child,
                    Scope = ScopeType.Regime,
                    AgeFrom = 2,
                    AgeTo = 14.99m,
                    Amount = anyC5dtn1,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 2,
                    PaxType = PaxType.Child,
                    Scope = ScopeType.Regime,
                    AgeFrom = 2,
                    AgeTo = 14.99m,
                    Amount = anyC5dtn2,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 3,
                    PaxType = PaxType.Child,
                    Scope = ScopeType.Regime,
                    AgeFrom = 2,
                    AgeTo = 14.99m,
                    Amount = anyC5dtn3,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 4,
                    PaxType = PaxType.Child,
                    Scope = ScopeType.Regime,
                    AgeFrom = 2,
                    AgeTo = 14.99m,
                    Amount = anyC5dtn4,
                    AmountType = PaymentType.Percent
                }
            },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));

    }

    [Test]
    public async Task create_extra_when_c5th_is_not_empty() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "A";
        const string anyC5th02 = "B";
        const string anyC5th03 = "C";
        const string anyC5th04 = "D";
        const string anyC5th05 = "E";
        const string anyC5th06 = "F";
        const string anyC5th07 = "G";
        const string anyC5th08 = "H";
        const string anyC5th09 = "I";
        const string anyC5th10 = "J";
        const string anyC5th11 = "K";
        const string anyC5th12 = "L";
        const string anyC5th13 = "M";
        const string anyC5th14 = "N";
        const string anyC5th15 = "Ñ";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //when
        await createExtra.Execute(anyConextra);

        //then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            Paxes = new List<ExtraPax>(),
            Rooms = new List<string> {
                anyC5th01,
                anyC5th02,
                anyC5th03,
                anyC5th04,
                anyC5th05,
                anyC5th06,
                anyC5th07,
                anyC5th08,
                anyC5th09,
                anyC5th10,
                anyC5th11,
                anyC5th12,
                anyC5th13,
                anyC5th14,
                anyC5th15
            }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5reg_is_not_empty() {
        // Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "A";
        const string anyC5reg2 = "B";
        const string anyC5reg3 = "C";
        const string anyC5reg4 = "D";
        const string anyC5reg5 = "E";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //when
        await createExtra.Execute(anyConextra);

        //then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            Paxes = new List<ExtraPax>(),
            Rooms = new List<string>(),
            Regimes = new List<string> {
                anyC5reg1,
                anyC5reg2,
                anyC5reg3,
                anyC5reg4,
                anyC5reg5
            }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5dta_is_not_zero() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 10.0m;
        const decimal anyC5dta2 = 20.0m;
        const decimal anyC5dta3 = 30.0m;
        const decimal anyC5dta4 = 40.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            Paxes = new List<ExtraPax> {
                new ExtraPax {
                    PaxOrder = 1,
                    PaxType = PaxType.Adult,
                    Scope = ScopeType.Regime,
                    AgeFrom = 15,
                    AgeTo = 999,
                    Amount = anyC5dta1,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 2,
                    PaxType = PaxType.Adult,
                    Scope = ScopeType.Regime,
                    AgeFrom = 15,
                    AgeTo = 999,
                    Amount = anyC5dta2,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 3,
                    PaxType = PaxType.Adult,
                    Scope = ScopeType.Regime,
                    AgeFrom = 15,
                    AgeTo = 999,
                    Amount = anyC5dta3,
                    AmountType = PaymentType.Percent
                },
                new ExtraPax {
                    PaxOrder = 4,
                    PaxType = PaxType.Adult,
                    Scope = ScopeType.Regime,
                    AgeFrom = 15,
                    AgeTo = 999,
                    Amount = anyC5dta4,
                    AmountType = PaymentType.Percent
                }
            }
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5sele_is_not_s() {
        //Then
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5Sele = "";
        const string anyC5foun = "U";
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5Sele(anyC5Sele)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedConextra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()            
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));

    }

    [Test]
    public async Task create_extra_when_c5cocu_is_zero() {
        //Given
        const int anyC5cocu = 0;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyc5foun = "U";
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5cocu(anyC5cocu)
            .WithC5foun(anyc5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = ""
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));

    }

    [Test]
    public async Task create_extra_when_c5foun_is_d() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5foun = "D";
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = ApplyStayPriceType.D,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));


    }

    [Test]
    public async Task create_extra_when_c5foun_is_p() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5foun = "P";
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = ApplyStayPriceType.P,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }
       
    [Test]
    public async Task create_extra_when_c5foun_is_x() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5foun = "X";
        const string anyC5form = "U";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = ApplyStayPriceType.X,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5form_is_d() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5form = "D";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.D,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5form_is_p() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5form = "P";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.P,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5form_is_x() {
        //Given
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5form = "X";
        const string anyC5apdt = "";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.X,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString()
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5apdt_is_c() {
        //Given
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "C";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.Contract,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            ContractClients = new List<string>() { anyOriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task create_extra_when_c5apdt_is_s() {
        //Given
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC5fred = 2024001;
        const int anyC5freh = 2024366;
        const int anyC5fec1 = 2024001;
        const int anyC5fec2 = 2024366;
        const string anyC5apdt = "S";
        const decimal anyC5dtn1 = 0.0m;
        const decimal anyC5dtn2 = 0.0m;
        const decimal anyC5dtn3 = 0.0m;
        const decimal anyC5dtn4 = 0.0m;
        const decimal anyC5dta1 = 0.0m;
        const decimal anyC5dta2 = 0.0m;
        const decimal anyC5dta3 = 0.0m;
        const decimal anyC5dta4 = 0.0m;
        const string anyC5th01 = "";
        const string anyC5th02 = "";
        const string anyC5th03 = "";
        const string anyC5th04 = "";
        const string anyC5th05 = "";
        const string anyC5th06 = "";
        const string anyC5th07 = "";
        const string anyC5th08 = "";
        const string anyC5th09 = "";
        const string anyC5th10 = "";
        const string anyC5th11 = "";
        const string anyC5th12 = "";
        const string anyC5th13 = "";
        const string anyC5th14 = "";
        const string anyC5th15 = "";
        const string anyC5reg1 = "";
        const string anyC5reg2 = "";
        const string anyC5reg3 = "";
        const string anyC5reg4 = "";
        const string anyC5reg5 = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5apdt(anyC5apdt)
            .WithC5dtn1(anyC5dtn1)
            .WithC5dtn2(anyC5dtn2)
            .WithC5dtn3(anyC5dtn3)
            .WithC5dtn4(anyC5dtn4)
            .WithC5dta1(anyC5dta1)
            .WithC5dta2(anyC5dta2)
            .WithC5dta3(anyC5dta3)
            .WithC5dta4(anyC5dta4)
            .WithC5th01(anyC5th01)
            .WithC5th02(anyC5th02)
            .WithC5th03(anyC5th03)
            .WithC5th04(anyC5th04)
            .WithC5th05(anyC5th05)
            .WithC5th06(anyC5th06)
            .WithC5th07(anyC5th07)
            .WithC5th08(anyC5th08)
            .WithC5th09(anyC5th09)
            .WithC5th10(anyC5th10)
            .WithC5th11(anyC5th11)
            .WithC5th12(anyC5th12)
            .WithC5th13(anyC5th13)
            .WithC5th14(anyC5th14)
            .WithC5th15(anyC5th15)
            .WithC5reg1(anyC5reg1)
            .WithC5reg2(anyC5reg2)
            .WithC5reg3(anyC5reg3)
            .WithC5reg4(anyC5reg4)
            .WithC5reg5(anyC5reg5)
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .Build();

        //When
        await createExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
            Code = anyConextra.Code,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 12, 31),
            CheckInFrom = new DateTime(2024, 01, 01),
            CheckInTo = new DateTime(2024, 12, 31),
            StayFrom = anyConextra.C5died,
            StayTo = anyConextra.C5dieh,
            Mandatory = anyConextra.C5Sele == "S" ? false : true,
            Quantity = anyConextra.C5unid,
            ByDay = anyConextra.C5inta,
            ApplyBy = anyConextra.C5foun == "D" ? ApplyStayPriceType.D : anyConextra.C5foun == "P" ? ApplyStayPriceType.P : anyConextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = anyConextra.C5form == "D" ? ApplyStayPriceType.D : anyConextra.C5form == "P" ? ApplyStayPriceType.P : anyConextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.Offer,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            ContractClients = new List<string>() { anyOriginCode },
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task do_not_create_extra_when_c5fred_is_invalid() {
        // Given
        const int anyC5fred = 2024;   

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply from date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5freh_is_invalid() {
        // Given
        const int anyC5freh = 2024;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5freh(anyC5freh)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply to date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5fec1_is_invalid() {
        // Given
        const int anyC5fec1 = 202401;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec1(anyC5fec1)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid check-in from date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5fec2_is_invalid() {
        // Given
        const int anyC5fec2 = 2024999;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec2(anyC5fec2)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid check-in to date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5freh_is_less_than_c5fred() {
        // Given
        const int anyC5fred = 2024002;
        const int anyC5freh = 2024001;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Apply to date is less than apply from date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5fec2_is_less_than_c5fec1() {
        // Given
        const int anyC5fec1 = 2024002;
        const int anyC5fec2 = 2024001;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Check-in to date is less than check-in from date");
    }

    [Test]
    public async Task do_not_create_extra_when_c5dieh_is_less_than_c5fied() {
        // Given
        const int anyC5died = 2;
        const int anyC5dieh = 1;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5died(anyC5died)
            .WithC5dieh(anyC5dieh)
            .Build();

        // When
        Func<Task> function = async () => await createExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Stay to date is less than stay from date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
