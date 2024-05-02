namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Tax;

[TestFixture]
public class PushStaticTaxesShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticTaxes pushStaticTaxes;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticTaxes = new PushStaticTaxes(staticSynchronizerApiClient);
    }

    [Test]
    public async Task push_static_taxes() {
        //Given
        var anyReszoims = new List<Reszoim>() {
            new() {
                Code = "anyCode1",
                Zotext = "anyZotext1",
                Zoporc = 7
            },
            new() {
                Code = "anyCode2",
                Zotext = "anyZotext2",
                Zoporc = 7.8m
            },
        };

        //when
        await pushStaticTaxes.Execute(anyReszoims);

        //Then
        var expectedTaxes = anyReszoims.Select(x => new Infrastructure.Dtos.BookingCenter.Static.Tax {
            Code = x.Code,
            Description = x.Zotext,
            Amount = x.Zoporc,
            AmountType = TypeOfPayment.Percent,
            Type = TaxType.Vat
        }).ToList();
        await staticSynchronizerApiClient.Received()
           .PushTaxes(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.Tax>>(x => IsEquivalent(x, expectedTaxes)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
