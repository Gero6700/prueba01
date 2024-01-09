using FluentAssertions;
using NSubstitute;
using Senator.As400.Cloud.Sync.Application.Dtos.As400;
using Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;
using Senator.As400.Cloud.Sync.Application.UseCases;
using Senator.As400.Cloud.Sync.Infrastructure.Providers;
using Senator.As400.Cloud.Sync.Tests.Common.Builders;


using System;
using System.Drawing;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases; 

[TestFixture]
public class CreateContractShould {
    private CreateContract createContract = null!;
    private IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient = null!;

    [SetUp]
    public void Setup() {
        availabilitySynchronizerApiClient = Substitute.For<IAvailabilitySynchronizerApiClient>();
        createContract = new CreateContract();
    }

    [Test]
    public async Task create_contract() {
        // Given
        const int anyCoagen = 10600;
        const int anyCosucu = 1;
        const int anyCohote = 150;
        const string anyCocont = "01";
        const int anyCofec1 = 2024001;
        const int anyCofec2 = 2024365;
        const int anyCoagcl = 10600;
        const int anyCosucl = 0;
        const int anyComone = 23;
        const int anyCovers = 0;
        //const string anyComerca = "E";

        var as400Concabec = ConcabecBuilder.AnConcabecBuilder()
            .WithCoagen(anyCoagen)
            .WithCosucu(anyCosucu)
            .WithCohote(anyCohote)
            .WithCocont(anyCocont)
            .WithCofec1(anyCofec1)
            .WithCofec2(anyCofec2)
            .WithCoagcl(anyCoagcl)
            .WithCosucl(anyCosucl)
            .WithComone(anyComone)
            .WithCovers(anyCovers)
            .Build();

        // When
        await createContract.Execute(as400Concabec);

        // Then
        var newContract = new Contract {
            code = anyCohote + anyCocont + anyCofec1 + anyCovers,
            description = as400Concabec.Codesc,
            valid_date_from = new DateTime(2024, 01, 01),
            valid_date_to = new DateTime(2024, 12, 31),
            tax_included = true,
            ordered_ages = OrderedAges.ASC,
            deposit_date = new DateTime(2024, 01, 01),
            deposit_type = DepositType.percent,
            hotel_code = anyCohote,
            currency_code = anyComone.ToString(),
            market = "E"
        };
        
        await availabilitySynchronizerApiClient.Received()
            .PushContract(Arg.Is<Contract>(rq => IsEquivalent(rq, newContract)));

    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}