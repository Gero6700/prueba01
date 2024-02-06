namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Room;

[TestFixture]
public class UpdateRoomShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private UpdateRoom updateRoom;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        updateRoom = new UpdateRoom(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task update_room() {
        //Given
        const string anyMthab = "D";
        var anyResthabi = new Resthabi {
            Mthab = anyMthab
        };

        //When
        await updateRoom.Execute(anyResthabi);

        //Then
        var expectedRoom = new Infrastructure.Dtos.BookingCenter.Room {
            Code = anyMthab
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateRoom(Arg.Is<Infrastructure.Dtos.BookingCenter.Room>(x => IsEquivalent(x, expectedRoom)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
