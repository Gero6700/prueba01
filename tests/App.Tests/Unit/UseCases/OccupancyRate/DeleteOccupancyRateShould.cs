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

}
