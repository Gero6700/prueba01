namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Inventory;

[TestFixture]
public class DeleteInventoryShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteInventory deleteInventory;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteInventory = new DeleteInventory();
    }

    [Test]
    public async Task delete_inventory() {
        //Given
        const int anyPtfec = 20240101;
        const int anyPthot = 150;
        const string anyPthab = "D";
        var anyResplaht = new Resplaht {
            Ptfec = anyPtfec,
            Pthot = anyPthot,
            Pthab = anyPthab
        };

        //When
        await deleteInventory.Execute(anyResplaht);

        //Then
        var expectedInventory = new Infrastructure.Dtos.BookingCenter.Inventory {
            InventoryDate = new DateTime(2024, 1, 1),
            HotelCode = anyPthot.ToString(),
            RoomCode = anyPthab
        };

        await availabilitySynchronizerApiClient.Received()
            .DeleteInventory(Arg.Is<Infrastructure.Dtos.BookingCenter.Inventory>(x => IsEquivalent(x, expectedInventory)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
