namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Room;

[TestFixture]
public class DeleteRoomShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteRoom deleteRoom;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteRoom = new DeleteRoom();
    }

    [Test]
    public async Task delete_room() {
        //Given
        const string anyMthab = "D";
        var anyResthabi = new Resthabi {
            Mthab = anyMthab
        };

        //When
        await deleteRoom.Execute(anyResthabi);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteRoom(anyMthab);
    }
    
}
