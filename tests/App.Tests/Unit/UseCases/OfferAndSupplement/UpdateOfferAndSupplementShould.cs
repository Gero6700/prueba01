using Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplement;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OfferAndSupplement;

[TestFixture]
public class UpdateOfferAndSupplementShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateOfferAndSupplement updateOfferAndSupplement;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateOfferAndSupplement = new UpdateOfferAndSupplement(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_offer_and_supplement() {
        //Given
        const int anyOffec = 2024001;
        const int anyOffec2 = 2024002;
        const int anyOfftop = 240604;
        const int anyOfgrbd = 20240301;
        const int anyOfgrbh = 20240305;
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
            .WithOfdae(anyOfdae)
            .WithOfdas(anyOfdas)
            .WithOfdne(anyOfdne)
            .WithOfdns(anyOfdns)
            .WithOfthab(anyOfthab)
            .WithOftser(anyOftser)
            .Build();
        
        //When
        await updateOfferAndSupplement.Execute(anyConofege);

        //Then
        var expectedOfferAndSupplement = new Infrastructure.Dtos.BookingCenter.OfferAndSupplement {
            Code = anyConofege.Code,
            Type = anyConofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = new DateTime(2024, 01, 01),
            ApplyTo = new DateTime(2024, 01, 02),
            ApplyOrder = null,
            DepositAmount = anyConofege.Ofdpto,
            DepositType = anyConofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = new DateTime(2024, 06, 04),
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
                    BookingWindowFrom = new DateTime(2024, 03, 01),
                    BookingWindowTo = new DateTime(2024, 03, 05),
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
                    ApplyStayPriceType = anyConofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = anyConofege.Ofpree,
                    ApplyRegimePriceType = anyConofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : anyConofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : anyConofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = anyConofege.Ofpres,
                    DiscountAmount = anyConofege.Ofdtos,
                    DicountAmountType = anyConofege.Oftidt.ToUpper() == "C" ? PaymentType.Fixed : PaymentType.Percent,
                    DiscountTarget = anyConofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : anyConofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    DiscountScope = anyConofege.Ofapli.ToUpper() == "E" ? DiscountScopeType.Stay : anyConofege.Ofapli.ToUpper() == "S" ? DiscountScopeType.Regime : DiscountScopeType.All,
                    Paxes = []
                }
            ]
        };
    }

    [Test]
    public async Task do_not_update_offer_and_supplement_when_offec_is_invalid() {
        //Given
        const int anyOffec = 2024;

        var anyConofege = ConofegeBuilder.AConofegeBuilder()
        .WithOffec(anyOffec)
            .Build();

        //When
        Func<Task> function = async () => await updateOfferAndSupplement.Execute(anyConofege);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply from date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
