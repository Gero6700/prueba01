namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Room;

[TestFixture]
public class CreateRoomShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private CreateRoom createRoom;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createRoom = new CreateRoom(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task create_room() {
        //Given
        const string anyMthab = "D";
        var anyResthabi = new Resthabi {
            Mthab = anyMthab
        };

        //when
        await createRoom.Execute(anyResthabi);

        //Then
        var expectedRoom = new Infrastructure.Dtos.BookingCenter.Room {
            Code = anyMthab
        };
        await availabilitySynchronizerApiClient.Received()
            .CreateRoom(Arg.Is<Infrastructure.Dtos.BookingCenter.Room>(x => IsEquivalent(x, expectedRoom)));
    }

    [Test]
    public async Task do_not_create_room_when_mthab_is_empty() {
        //Given
        var anyResthabi = new Resthabi {
            Mthab = string.Empty
        };

        //When
        Func<Task> function = async () => await createRoom.Execute(anyResthabi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect room code");
        
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
