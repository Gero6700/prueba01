namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Category;

[TestFixture]
public class CreateCategoryShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private CreateCategory createCategory;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        createCategory = new CreateCategory(staticSynchronizerApiClient);
    }

    [Test]
    public async Task create_category() {
        //Given
        const int anyId = 1;
        const string anyName = "anyName";

        var anyMarcaComercial = new MarcaComercial {
            Id = anyId,
            Nombre = anyName
        };

        //When
        await createCategory.Execute(anyMarcaComercial);

        //Then
        var expectedCategory = new Infrastructure.Dtos.BookingCenter.Static.Category {
            Code = anyId.ToString(),
            Translations = [
                new() {
                    Name = anyName,
                    LanguageIsoCode = "es-ES"
                }
            ]
        };

        await staticSynchronizerApiClient.Received()
            .CreateCategory(Arg.Is<Infrastructure.Dtos.BookingCenter.Static.Category>(x => IsEquivalent(x, expectedCategory)));
    }

    [Test]
    public async Task do_not_create_category_when_id_is_zero() {
        //Given
        const int anyId = 0;
        const string anyName = "anyName";

        var anyMarcaComercial = new MarcaComercial {
            Id = anyId,
            Nombre = anyName
        };

        //When
        Func<Task> action = async () => await createCategory.Execute(anyMarcaComercial);

        //Then
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Category code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
