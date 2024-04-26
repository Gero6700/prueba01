namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Service;

[TestFixture]
public class PushStaticServicesShould{
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticServices pushStaticServices;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticServices = new PushStaticServices();
    }

    [Test]
    public async Task push_static_services() {
        //Given
        var givenEstServicios = new List<EstServicio>() {
            EstServicioBuilder.AnEstServicioBuilder().Build(),
            EstServicioBuilder.AnEstServicioBuilder().Build()
        };

        //when
        await pushStaticServices.Execute(givenEstServicios);

        //Then
        var expectedServices = new List<Infrastructure.Dtos.BookingCenter.Static.Service>() {
            new () {
                Code = givenEstServicios[0].Id.ToString(),
                CategoryCode = givenEstServicios[0].IdCategoria.ToString(),
                Translations = [
                    new() { Name = givenEstServicios[0].EsServicio, LanguageIsoCode = "es-ES" },
                    new() { Name = givenEstServicios[0].EnServicio, LanguageIsoCode = "en-GB" },
                    new() { Name = givenEstServicios[0].FrServicio, LanguageIsoCode = "fr-FR" },
                    new() { Name = givenEstServicios[0].DeServicio, LanguageIsoCode = "de-DE" },
                    new() { Name = givenEstServicios[0].PtServicio, LanguageIsoCode = "pt-PT" }
                ]
            },
            new () {
                Code = givenEstServicios[1].Id.ToString(),
                CategoryCode = givenEstServicios[1].IdCategoria.ToString(),
                Translations = [
                    new() { Name = givenEstServicios[1].EsServicio, LanguageIsoCode = "es-ES" },
                    new() { Name = givenEstServicios[1].EnServicio, LanguageIsoCode = "en-GB" },
                    new() { Name = givenEstServicios[1].FrServicio, LanguageIsoCode = "fr-FR" },
                    new() { Name = givenEstServicios[1].DeServicio, LanguageIsoCode = "de-DE" },
                    new() { Name = givenEstServicios[1].PtServicio, LanguageIsoCode = "pt-PT" }
                ]
            }
        };
        await staticSynchronizerApiClient.Received()
            .PushServices(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.Service>>(x => IsEquivalent(x, expectedServices)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
