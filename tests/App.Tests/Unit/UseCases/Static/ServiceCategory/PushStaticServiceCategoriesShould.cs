using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.ServiceCategory;

[TestFixture]
public class PushStaticServiceCategoriesShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticServiceCategories pushStaticCategoriesService;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticCategoriesService = new PushStaticServiceCategories(staticSynchronizerApiClient);
    }

    [Test]
    public async Task push_static_service_categories() {
        //Given
        var givenEstServicioCategorias = new List<EstServicioCategoria>() { 
            EstServicioCategoriaBuilder.AnEstServicioCategoriaBuilder().Build(),
            EstServicioCategoriaBuilder.AnEstServicioCategoriaBuilder().Build()
        };

        //When
        await pushStaticCategoriesService.Execute(givenEstServicioCategorias);

        //Then
        var expectedServiceCategories = new List<Infrastructure.Dtos.BookingCenter.Static.ServiceCategory>() {
            new () {
                Code = givenEstServicioCategorias[0].Id.ToString(),
                Translations = [
                    new() { Name = givenEstServicioCategorias[0].EsNombre, LanguageIsoCode = Language.Es.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[0].EnNombre, LanguageIsoCode = Language.En.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[0].FrNombre, LanguageIsoCode = Language.Fr.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[0].DeNombre, LanguageIsoCode = Language.De.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[0].PtNombre, LanguageIsoCode = Language.Pt.GetIsoCode() }
                    ]
            },
            new () {
                Code = givenEstServicioCategorias[1].Id.ToString(),
                Translations = [
                    new() { Name = givenEstServicioCategorias[1].EsNombre, LanguageIsoCode = Language.Es.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[1].EnNombre, LanguageIsoCode = Language.En.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[1].FrNombre, LanguageIsoCode = Language.Fr.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[1].DeNombre, LanguageIsoCode = Language.De.GetIsoCode() },
                    new() { Name = givenEstServicioCategorias[1].PtNombre, LanguageIsoCode = Language.Pt.GetIsoCode() }
                    ]
            }
        };
        await staticSynchronizerApiClient.Received()
            .PushServiceCategories(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.ServiceCategory>>(x => IsEquivalent(x, expectedServiceCategories)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
