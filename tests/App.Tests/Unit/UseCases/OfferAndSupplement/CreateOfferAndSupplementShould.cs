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
        const int anyOfgrbd = 2024001;
        const int anyOfgrbh = 2024002;
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
            Conditions = [],
            Configurations = []
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
        const int anyOfgrbd = 2024001;
        const int anyOfgrbh = 2024002;
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
            Conditions = [],
            Configurations = []
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
        const int anyOfgrbd = 2024001;
        const int anyOfgrbh = 2024002;
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
            Conditions = [],
            Configurations = []
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateOfferAndSupplement(Arg.Is<Infrastructure.Dtos.BookingCenter.OfferAndSupplement>(x => IsEquivalent(x, expectedOfferAndSupplement)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
