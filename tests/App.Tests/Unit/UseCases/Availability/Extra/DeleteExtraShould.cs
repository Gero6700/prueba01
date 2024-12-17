namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Availability.Extra;

[TestFixture]
public class DeleteExtraShould {
    IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    DeleteExtra deleteExtra;

    [SetUp]
    public void SetUp() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        deleteExtra = new DeleteExtra(availabilitySynchronizerApiClient);
    }

    [Test]
    public async Task delete_extra() {
        //Given
        var anyCode = "1234";
        var anyConextra = ConextraBuilder.AConextraBuilder().WithCode(anyCode).Build();

        //When
        await deleteExtra.Execute(anyConextra);

        //Then
        var expectedCode = anyCode.ToString();
        await availabilitySynchronizerApiClient.Received()
            .DeleteExtra(Arg.Is<string>(c => IsEquivalent(c, expectedCode)));
    }
    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
