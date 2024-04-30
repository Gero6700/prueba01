namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.PaymentType;
public class PushStaticPaymentTypesShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticPaymentTypes pushStaticPaymentTypes;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticPaymentTypes = new PushStaticPaymentTypes(staticSynchronizerApiClient);
    }

    [Test]
    public async Task push_static_payment_types() {
        //Given
        var anyForpagos = new List<Forpago>() {
            new() {
                Codpag = "anyCodPag1",
                Despag = "anyDesPag2",
                Precre = "C"
            },
            new() {
                Codpag = "anyCodPag2",
                Despag = "anyDesPag2",
                Precre = "C"
            },
        };

        //when
        await pushStaticPaymentTypes.Execute(anyForpagos);

        //Then
        var expectedPaymentTypes = anyForpagos.Select(x => new Infrastructure.Dtos.BookingCenter.Static.PaymentType {
            Code = x.Codpag,
            Description = x.Despag,
            CreditOrPrepay = CreditOrPrepayType.Credit
        }).ToList();       

        await staticSynchronizerApiClient.Received()
            .PushPaymentTypes(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.PaymentType>>(x => IsEquivalent(x, expectedPaymentTypes)));
    }

    [Test]
    public async Task push_static_payment_types_when_precre_is_p() {
        //Given
        var anyForpagos = new List<Forpago>() {
            new() {
                Codpag = "anyCodPag1",
                Despag = "anyDesPag2",
                Precre = "P"
            },
            new() {
                Codpag = "anyCodPag2",
                Despag = "anyDesPag2",
                Precre = "P"
            },
        };

        //when
        await pushStaticPaymentTypes.Execute(anyForpagos);

        //Then
        var expectedPaymentTypes = anyForpagos.Select(x => new Infrastructure.Dtos.BookingCenter.Static.PaymentType {
            Code = x.Codpag,
            Description = x.Despag,
            CreditOrPrepay = CreditOrPrepayType.Prepay
        }).ToList();       

        await staticSynchronizerApiClient.Received()
            .PushPaymentTypes(Arg.Is<List<Infrastructure.Dtos.BookingCenter.Static.PaymentType>>(x => IsEquivalent(x, expectedPaymentTypes)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
