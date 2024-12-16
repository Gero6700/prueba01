namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Extra;

[TestFixture]
public class UpdateExtraShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateExtra updateExtra;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateExtra = new UpdateExtra(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_extra() {
        //Given
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Contract;
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
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .Build();

        //When
        await updateExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Availability.Extra {
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
            DiscountApplicationType = ExtrasDiscountApplicationType.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            ContractClients = new List<string> { anyOriginCode },
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task update_extra_when_c5fred_is_zero() {
        //Given
        const string anyOriginCode = "anyOriginCode";
        const OriginType anyOriginType = OriginType.Contract;
        const int anyC5fred = 0;
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
            .WithOriginCode(anyOriginCode)
            .WithOriginType(anyOriginType)
            .Build();

        //When
        await updateExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Availability.Extra {
            Code = anyConextra.Code,
            ApplyFrom = null,
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
            DiscountApplicationType = ExtrasDiscountApplicationType.All,
            IsCancellationGuarantee = anyConextra.Cogc,
            OccupancyRateCod = anyConextra.C5cocu.ToString(),
            ContractClients = new List<string> { anyOriginCode },
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Extra>(x => IsEquivalent(x, expectedExtra)));
    }

    [Test]
    public async Task do_not_update_extra_when_c5fred_is_invalid() {
        // Given
        const int anyC5fred = 2024;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply from date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5freh_is_invalid() {
        // Given
        const int anyC5freh = 2024;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5freh(anyC5freh)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid apply to date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5fec1_is_invalid() {
        // Given
        const int anyC5fec1 = 202401;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec1(anyC5fec1)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid check-in from date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5fec2_is_invalid() {
        // Given
        const int anyC5fec2 = 2024999;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec2(anyC5fec2)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid check-in to date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5freh_is_less_than_c5fred() {
        // Given
        const int anyC5fred = 2024002;
        const int anyC5freh = 2024001;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fred(anyC5fred)
            .WithC5freh(anyC5freh)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Apply to date is less than apply from date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5fec2_is_less_than_c5fec1() {
        // Given
        const int anyC5fec1 = 2024002;
        const int anyC5fec2 = 2024001;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5fec1(anyC5fec1)
            .WithC5fec2(anyC5fec2)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Check-in to date is less than check-in from date");
    }

    [Test]
    public async Task do_not_update_extra_when_c5dieh_is_less_than_c5fied() {
        // Given
        const int anyC5died = 2;
        const int anyC5dieh = 1;

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithC5died(anyC5died)
            .WithC5dieh(anyC5dieh)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Stay to date is less than stay from date");
    }

    [Test]
    public async Task do_not_update_extra_when_origincode_is_empty() {
        // Given
        const string anyOriginCode = "";

        var anyConextra = ConextraBuilder.AConextraBuilder()
            .WithOriginCode(anyOriginCode)
            .Build();

        // When
        Func<Task> function = async () => await updateExtra.Execute(anyConextra);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Origin code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
