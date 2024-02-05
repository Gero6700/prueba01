using Senator.As400.Cloud.Sync.Application.UseCases.Inventory;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Inventory;

[TestFixture]
public class UpdateInventoryShould
{
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateInventory updateInventory;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateInventory = new UpdateInventory(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_inventory() {
        //Then
        const int anyPtfec = 20240101;
        const int anyPtcupo = 5;
        const int anyPtbloq = 0;
        const int anyPtreal = 0;
        const int anyPtgrup = 0;
        const int anyPtreag = 0;
        const int anyPthot = 150;
        const string anyPthab = "D";
        var anyResplaht = new Resplaht {
            Ptfec = anyPtfec,
            Ptcupo = anyPtcupo,
            Ptbloq = anyPtbloq,
            Ptreal = anyPtreal,
            Ptgrup = anyPtgrup,
            Ptreag = anyPtreag,
            Pthot = anyPthot,
            Pthab = anyPthab
        };

        //When
        await updateInventory.Execute(anyResplaht);

        //Then
        var expectedInventory = new Infrastructure.Dtos.BookingCenter.Inventory {
            InventoryDate = new DateTime(2024, 1, 1),
            RoomQuantity =anyResplaht.GetRoomQuantity,
            HotelCode = anyPthot.ToString(),
            RoomCode = anyPthab
        };

        await availabilitySynchronizerApiClient.Received()
            .UpdateInventory(Arg.Is<Infrastructure.Dtos.BookingCenter.Inventory>(x => IsEquivalent(x, expectedInventory)));

    }

    [Test]
    public async Task do_not_update_inventory_when_ptfec_is_invalid() {
        //Given
        const int anyPtfec = 2024;
        const int anyPtcupo = 5;
        const int anyPtbloq = 0;
        const int anyPtreal = 0;
        const int anyPtgrup = 0;
        const int anyPtreag = 0;
        const int anyPthot = 150;
        const string anyPthab = "D";
        var anyResplaht = new Resplaht {
            Ptfec = anyPtfec,
            Ptcupo = anyPtcupo,
            Ptbloq = anyPtbloq,
            Ptreal = anyPtreal,
            Ptgrup = anyPtgrup,
            Ptreag = anyPtreag,
            Pthot = anyPthot,
            Pthab = anyPthab
        };

        // When
        Func<Task> function = async () => await updateInventory.Execute(anyResplaht);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid date");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
