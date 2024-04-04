namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Category;

[TestFixture]
public class CreateCategoryShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private CreateCategory createCategory;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        createCategory = new CreateCategory();
    }

    [Test]
    public async Task create_category() {
        //Given
        const string anyId = "anyId";
        const string anyName = "anyName";

        var anyMarcaComercial = new MarcaComercial {
            Id = anyId,
            Nombre = anyName
        };

        //When
        await createCategory.Execute(anyMarcaComercial);

        //Then
        var expectedCategory = new Infrastructure.Dtos.BookingCenter.Static.Category {
            Code = anyId,
            Translations = new List<Translation> {
                new() {
                    Name = anyName,
                    LanguageIsoCode = "es-ES"
                }
            }
        };

        await staticSynchronizerApiClient.Received()
            .CreateCategory(Arg.Is<Infrastructure.Dtos.BookingCenter.Static.Category>(x => IsEquivalent(x, expectedCategory)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
