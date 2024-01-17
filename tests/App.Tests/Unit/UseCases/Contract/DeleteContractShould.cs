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
        const int anyCohote = 150;
        const string anyCocont = "01";
        const int anyCofec1 = 2024001;
        const int anyCovers = 0;
        
        var anyConcabec = ConcabecBuilder.AConcabecBuilder()
            .WithCohote(anyCohote)
            .WithCocont(anyCocont)
            .WithCofec1(anyCofec1)
            .WithCovers(anyCovers)
            .Build();

        // When
        await createContract.Execute(anyConcabec);

        // Then
        var expectedCode = string.Concat(anyCohote, anyCocont, anyCofec1, anyCovers);
       
        await availabilitySynchronizerApiClient.Received()
            .DeleteContract(Arg.Is<String>(c => IsEquivalent(c, expectedCode)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}