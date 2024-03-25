namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Contract;

[TestFixture]
public class DeleteContractShould {
    private DeleteContract deleteContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteContract = new DeleteContract(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_contract() {
        // Given
        const string anyContractClientCode = "anyContractClientCode";        
       
        // When
        await deleteContract.Execute(anyContractClientCode);

        // Then
        var expectedCode = anyContractClientCode;
       
        await availabilitySynchronizerApiClient.Received()
            .DeleteContractClient(Arg.Is<String>(c => IsEquivalent(c, expectedCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}