using Senator.As400.Cloud.Sync.Application.UseCases.Extra;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Extra;

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
        await updateExtra.Execute(anyConextra);

        //Then
        var expectedExtra = new Infrastructure.Dtos.BookingCenter.Extra {
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
            .UpdateExtra(Arg.Is<Infrastructure.Dtos.BookingCenter.Extra>(x => IsEquivalent(x, expectedExtra)));
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

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
