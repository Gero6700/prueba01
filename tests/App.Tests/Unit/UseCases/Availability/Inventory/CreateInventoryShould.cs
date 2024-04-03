namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Inventory;

[TestFixture]
public class CreateInventoryShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateInventory createInventory;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createInventory = new CreateInventory(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_inventory() {
        //Given
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
        await createInventory.Execute(anyResplaht);

        //Then
        var expectedInventory = new Infrastructure.Dtos.BookingCenter.Availability.Inventory {
            InventoryDate = new DateTime(2024, 1, 1),
            RoomQuantity = anyPtcupo - anyPtbloq - anyPtreal - anyPtgrup - anyPtreag,
            HotelCode = anyPthot.ToString(),
            RoomCode = anyPthab
        };

        await availabilitySynchronizerApiClient.Received()
            .CreateInventory(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Inventory>(x => IsEquivalent(x, expectedInventory)));

    }

    [Test]
    public async Task do_not_create_inventory_when_ptfec_is_invalid() {
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
        Func<Task> function = async () => await createInventory.Execute(anyResplaht);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid date");

    }

    [Test]
    public async Task do_not_create_inventory_when_pthot_is_zero() {
        //Given
        const int anyPtfec = 20240101;
        const int anyPtcupo = 5;
        const int anyPtbloq = 0;
        const int anyPtreal = 0;
        const int anyPtgrup = 0;
        const int anyPtreag = 0;
        const int anyPthot = 0;
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
        Func<Task> function = async () => await createInventory.Execute(anyResplaht);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect hotel code");

    }

    [Test]
    public async Task do_not_create_inventory_when_pthab_is_empty() {
        //Given
        const int anyPtfec = 20240101;
        const int anyPtcupo = 5;
        const int anyPtbloq = 0;
        const int anyPtreal = 0;
        const int anyPtgrup = 0;
        const int anyPtreag = 0;
        const int anyPthot = 150;
        const string anyPthab = "";
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
        Func<Task> function = async () => await createInventory.Execute(anyResplaht);

        // Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect room code");

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }


}
