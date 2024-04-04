namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Category;

[TestFixture]
public class UpdateCategoryShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private UpdateCategory updateCategory;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        updateCategory = new UpdateCategory(staticSynchronizerApiClient);
    }

    [Test]
    public async Task update_category() {
        //Given
        const int anyId = 1;
        const string anyName = "anyName";

        var anyMarcaComercial = new MarcaComercial {
            Id = anyId,
            Nombre = anyName
        };

        //When
        await updateCategory.Execute(anyMarcaComercial);

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
            .UpdateCategory(Arg.Is<Infrastructure.Dtos.BookingCenter.Static.Category>(x => IsEquivalent(x, expectedCategory)));
    }

    [Test]
    public async Task do_not_update_category_when_id_is_zero() {
        //Given
        const int anyId = 0;
        const string anyName = "anyName";

        var anyMarcaComercial = new MarcaComercial {
            Id = anyId,
            Nombre = anyName
        };

        //When
        Func<Task> action = async () => await updateCategory.Execute(anyMarcaComercial);

        //Then
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Category code is required");
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
