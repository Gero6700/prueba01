namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Room;

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
        var expectedRoom = new Infrastructure.Dtos.BookingCenter.Availability.Room {
            Code = anyMthab
        };
        await availabilitySynchronizerApiClient.Received()
            .UpdateRoom(Arg.Is<Infrastructure.Dtos.BookingCenter.Availability.Room>(x => IsEquivalent(x, expectedRoom)));
    }

    [Test]
    public async Task do_not_update_room_when_mthab_is_empty() {
        //Given
        var anyResthabi = new Resthabi {
            Mthab = string.Empty
        };

        //When
        Func<Task> function = async () => await updateRoom.Execute(anyResthabi);

        //Then
        await function.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect room code");

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
