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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithCode(anyCode)
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
            OccupancyRateCod = anyC5cocu.ToString()      
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedConextra)));
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5Sele(anyC5Sele)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5cocu(anyC5cocu)
            .WithC5foun(anyc5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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
            ApplyBy = ApplyStayPriceType.U,
            Price = anyConextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5foun(anyC5foun)
            .WithC5form(anyC5form)
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .WithC5form(anyC5form)
            .WithC5apdt(anyC5apdt)
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

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
