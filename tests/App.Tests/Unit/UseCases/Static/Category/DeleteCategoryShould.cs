namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Category;

[TestFixture]
public class DeleteCategoryShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private DeleteCategory deleteCategory;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        deleteCategory = new DeleteCategory(staticSynchronizerApiClient);
    }

    [Test]
    public async Task delete_category() {
        //Given
        const int anyId = 1;

        //When
        await deleteCategory.Execute(anyId);

        //Then
        var expectedId = anyId.ToString();
        await staticSynchronizerApiClient.Received()
            .DeleteCategory(Arg.Is<string>(x => IsEquivalent(x, expectedId)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }

}
