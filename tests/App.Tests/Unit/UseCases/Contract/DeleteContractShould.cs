namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Contract;

[TestFixture]
public class DeleteContractShould {
    private DeleteContract createContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createContract = new DeleteContract(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_contract() {
        // Given
        const string anyContractCode = "anyContractCode";
        
       
        // When
        await createContract.Execute(anyContractCode);

        // Then
        var expectedCode = anyContractCode;
       
        await availabilitySynchronizerApiClient.Received()
            .DeleteContract(Arg.Is<String>(c => IsEquivalent(c, expectedCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}