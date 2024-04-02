namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.OccupancyRate;

[TestFixture]
public class DeleteOccupancyRateShould {
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    private DeleteOccupancyRate deleteOccupancyRate;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteOccupancyRate = new DeleteOccupancyRate(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_occupancy_rate() {
        //Given
        const string anyCocod = "anyCocod";

        //When
        await deleteOccupancyRate.Execute(anyCocod);

        //Then
        await availabilitySynchronizerApiClient.Received()
            .DeleteOccupancyRate(anyCocod);
    }

    [Test]
    public async Task do_not_delete_occupancy_rate_when_cocod_is_empty() {
        //Given
        const string anyCocod = "";

        //When
        Func<Task> act = async () => await deleteOccupancyRate.Execute(anyCocod);

        //Then
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Code is required");
    }
}
