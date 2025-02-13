using Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelSeason;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
using Senator.As400.Cloud.Sync.Application.UseCases.Static;

namespace Senator.As400.Cloud.Sync.Application.Handlers;
public class GenericEventHandler(
    ICreateCancellationPolicy createCancellationPolicyLine,
    IUpdateCancellationPolicy updateCancellationPolicyLine,
    ICreateIntegration createClient,
    IUpdateIntegration updateClient,
    IDeleteIntegration deleteClient,
    ICreateIntegrationClientType createClientType,
    IUpdateIntegrationClientType updateClientType,
    IDeleteIntegrationClientType deleteClientType,
    ICreateContractHeader createContract,
    IUpdateContractHeader updateContract,
    ICreateExtra createExtra,
    IUpdateExtra updateExtra,
    IDeleteExtra deleteExtra,
    ICreateHotel createHotel,
    IUpdateHotel updateHotel,
    IPushHotelRoomConfiguration pushHotelRoomConfiguration,
    IPushHotelSeason pushHotelSeason,
    ICreateInventory createInventory,
    IUpdateInventory updateInventory,
    ICreateMarket createMarket,
    ICreateMinimumStay createMinimumStay,
    IUpdateMinimumStay updateMinimumStay,
    IDeleteMinimumStay deleteMinimumStay,
    ICreateOccupancyRate createOccupancyRate,
    IUpdateOccupancyRate updateOccupancyRate,
    ICreateOfferSupplement createOfferAndSupplement,
    IUpdateOfferSupplement updateOfferAndSupplement,
    ICreateOfferSupplementConfigurationPax createOfferAndSupplementConfigurationPax,
    IUpdateOfferSupplementConfigurationPax updateOfferAndSupplementConfigurationPax,
    IDeleteOfferSupplementConfigurationPax deleteOfferAndSupplementConfigurationPax,
    ICreateOfferSupplementGroup createOfferAndSupplementGroup,
    IUpdateOfferSupplementGroup updateOfferAndSupplementGroup,
    ICreateOfferSupplementGroupRelation createOfferAndSupplementGroupOfferAndSupplement,
    IDeleteOfferSupplementGroupRelation deleteOfferAndSupplementGroupOfferAndSupplement,
    ICreatePeriodPricing createPeriodPricing,
    IUpdatePeriodPricing updatePeriodPricing,
    ICreatePeriodPricingPax createPeriodPricingPax,
    IUpdatePeriodPricingPax updatePeriodPricingPax,
    IDeletePeriodPricingPax deletePeriodPricingPax,
    ICreateMeal createRegimen,
    ICreateRoom createRoom,
    ICreateStaticExtraTranslation createStaticExtraTranslation,
    IUpdateStaticExtraTranslation updateStaticExtraTranslation,
    IDeleteStaticExtraTranslation deleteStaticExtraTranslation,
    ICreateStaticOfferSupplementTranslation createStaticOfferSupplementTranslation,
    IUpdateStaticOfferSupplementTranslation updateStaticOfferSupplementTranslation,
    IDeleteStaticOfferSupplementTranslation deleteStaticOfferSupplementTranslation,
    ICreateStaticPaymentType createStaticPaymentType,
    IUpdateStaticPaymentType updateStaticPaymentType,
    IDeleteStaticPaymentType deleteStaticPaymentType,
    ICreateStaticTax createStaticTax,
    IUpdateStaticTax updateStaticTax,
    IDeleteStaticTax deleteStaticTax
    ) : ISynchronizerHandler<GenericSynchronizationEvent> {
    private readonly ICreateCancellationPolicy createCancellationPolicyLine = createCancellationPolicyLine;
    private readonly IUpdateCancellationPolicy updateCancellationPolicyLine = updateCancellationPolicyLine;
    private readonly ICreateIntegration createClient = createClient;
    private readonly IUpdateIntegration updateClient = updateClient;
    private readonly IDeleteIntegration deleteClient = deleteClient;
    private readonly ICreateIntegrationClientType createClientType = createClientType;
    private readonly IUpdateIntegrationClientType updateClientType = updateClientType;
    private readonly IDeleteIntegrationClientType deleteClientType = deleteClientType;
    private readonly ICreateContractHeader createContract = createContract;
    private readonly IUpdateContractHeader updateContract = updateContract;
    private readonly ICreateExtra createExtra = createExtra;
    private readonly IUpdateExtra updateExtra = updateExtra;
    private readonly IDeleteExtra deleteExtra = deleteExtra;
    private readonly ICreateHotel createHotel = createHotel;
    private readonly IUpdateHotel updateHotel = updateHotel;
    private readonly IPushHotelRoomConfiguration pushHotelRoomConfiguration = pushHotelRoomConfiguration;
    private readonly IPushHotelSeason pushHotelSeason = pushHotelSeason;
    private readonly ICreateInventory createInventory = createInventory;
    private readonly IUpdateInventory updateInventory = updateInventory;
    private readonly ICreateMarket createMarket = createMarket;
    private readonly ICreateMinimumStay createMinimumStay = createMinimumStay;
    private readonly IUpdateMinimumStay updateMinimumStay = updateMinimumStay;
    private readonly IDeleteMinimumStay deleteMinimumStay = deleteMinimumStay;
    private readonly ICreateOccupancyRate createOccupancyRate = createOccupancyRate;
    private readonly IUpdateOccupancyRate updateOccupancyRate = updateOccupancyRate;
    private readonly ICreateOfferSupplement createOfferAndSupplement = createOfferAndSupplement;
    private readonly IUpdateOfferSupplement updateOfferAndSupplement = updateOfferAndSupplement;
    private readonly ICreateOfferSupplementConfigurationPax createOfferAndSupplementConfigurationPax = createOfferAndSupplementConfigurationPax;
    private readonly IUpdateOfferSupplementConfigurationPax updateOfferAndSupplementConfigurationPax = updateOfferAndSupplementConfigurationPax;
    private readonly IDeleteOfferSupplementConfigurationPax deleteOfferAndSupplementConfigurationPax = deleteOfferAndSupplementConfigurationPax;
    private readonly ICreateOfferSupplementGroup createOfferAndSupplementGroup = createOfferAndSupplementGroup;
    private readonly IUpdateOfferSupplementGroup updateOfferAndSupplementGroup = updateOfferAndSupplementGroup;
    private readonly ICreateOfferSupplementGroupRelation createOfferAndSupplementGroupOfferAndSupplement = createOfferAndSupplementGroupOfferAndSupplement;
    private readonly IDeleteOfferSupplementGroupRelation deleteOfferAndSupplementGroupOfferAndSupplement = deleteOfferAndSupplementGroupOfferAndSupplement;
    private readonly ICreatePeriodPricing createPeriodPricing = createPeriodPricing;
    private readonly IUpdatePeriodPricing updatePeriodPricing = updatePeriodPricing;
    private readonly ICreatePeriodPricingPax createPeriodPricingPax = createPeriodPricingPax;
    private readonly IUpdatePeriodPricingPax updatePeriodPricingPax = updatePeriodPricingPax;
    private readonly IDeletePeriodPricingPax deletePeriodPricingPax = deletePeriodPricingPax;
    private readonly ICreateMeal createRegimen = createRegimen;
    private readonly ICreateRoom createRoom = createRoom;
    private readonly ICreateStaticExtraTranslation createStaticExtraTranslation = createStaticExtraTranslation;
    private readonly IUpdateStaticExtraTranslation updateStaticExtraTranslation = updateStaticExtraTranslation;
    private readonly IDeleteStaticExtraTranslation deleteStaticExtraTranslation = deleteStaticExtraTranslation;
    private readonly ICreateStaticOfferSupplementTranslation createStaticOfferSupplementTranslation = createStaticOfferSupplementTranslation;
    private readonly IUpdateStaticOfferSupplementTranslation updateStaticOfferSupplementTranslation = updateStaticOfferSupplementTranslation;
    private readonly IDeleteStaticOfferSupplementTranslation deleteStaticOfferSupplementTranslation = deleteStaticOfferSupplementTranslation;
    private readonly ICreateStaticPaymentType createStaticPaymentType = createStaticPaymentType;
    private readonly IUpdateStaticPaymentType updateStaticPaymentType = updateStaticPaymentType;
    private readonly IDeleteStaticPaymentType deleteStaticPaymentType = deleteStaticPaymentType;
    private readonly ICreateStaticTax createStaticTax = createStaticTax;
    private readonly IUpdateStaticTax updateStaticTax = updateStaticTax;
    private readonly IDeleteStaticTax deleteStaticTax = deleteStaticTax;

    public async Task<HttpResponseMessage> HandleAsync(GenericSynchronizationEvent @event) {
        switch (@event.Table) {
            case nameof(TableType.CancellationPolicyLine):
                var cancellationPolicyLine = (Congasan)@event.Entity;
                return await HandleCancellationPolicyLineEventAsync(cancellationPolicyLine, @event.Operation);
            case nameof(TableType.Client):
                var client = (Usureg)@event.Entity;
                return await HandleClientEventAsync(client, @event.Operation);
            case nameof(TableType.ClientType):
                var clientType = (Restagen)@event.Entity;
                return await HandleClientTypeEventAsync(clientType, @event.Operation);
            case nameof(TableType.Contract):
                var contract = (Concabec)@event.Entity;
                return await HandleContractEventAsync(contract, @event.Operation);
            case nameof(TableType.Extra):
                var extra = (Conextra)@event.Entity;
                return await HandleExtraEventAsync(extra, @event.Operation);
            case nameof(TableType.Hotel):
                var hotel = (Reshotel)@event.Entity;
                return await HandleHotelEventAsync(hotel, @event.Operation);
            case nameof(TableType.HotelRoomConfiguration):
                var hotelRoomConfiguration = (Resthaho)@event.Entity;
                return await HandleHotelRoomConfigurationEventAsync(hotelRoomConfiguration, @event.Operation);
            case nameof(TableType.HotelSeason):
                var hotelSeason = (Hotape)@event.Entity;
                return await HandleHotelSeasonEventAsync(hotelSeason, @event.Operation);
            case nameof(TableType.Inventory):
                var inventory = (Resplaht)@event.Entity;
                return await HandleInventoryEventAsync(inventory, @event.Operation);
            case nameof(TableType.Market):
                var market = (Merca)@event.Entity;
                return await HandleMarketEventAsync(market, @event.Operation);
            case nameof(TableType.MinimumStay):
                var minimumStay = (Conestmi)@event.Entity;
                return await HandleMinimumStayEventAsync(minimumStay, @event.Operation);
            case nameof(TableType.OccupancyRate):
                var occupancyRate = (Resthaco)@event.Entity;
                return await HandleOccupancyRateEventAsync(occupancyRate, @event.Operation);
            case nameof(TableType.OfferAndSupplement):
                var offerAndSupplement = (Conofege)@event.Entity;
                return await HandleOfferAndSupplementEventAsync(offerAndSupplement, @event.Operation);
            case nameof(TableType.OfferAndSupplementConfigurationPax):
                var offerAndSupplementConfigurationPax = (Condtof)@event.Entity;
                return await HandleOfferAndSupplementConfigurationPaxEventAsync(offerAndSupplementConfigurationPax, @event.Operation);
            case nameof(TableType.OfferAndSupplementGroup):
                var offerAndSupplementGroup = (ConofcomHeader)@event.Entity;
                return await HandleOfferAndSupplementGroupEventAsync(offerAndSupplementGroup, @event.Operation);
            case nameof(TableType.OfferAndSupplementGroupOfferAndSupplement):
                var offerAndSupplementGroupOfferAndSupplement = (ConofcomLine)@event.Entity;
                return await HandleOfferAndSupplementGroupOfferAndSupplementEventAsync(offerAndSupplementGroupOfferAndSupplement, @event.Operation);
            case nameof(TableType.PeriodPricing):
                var periodPricing = (Conpreci)@event.Entity;
                return await HandlePeriodPricingEventAsync(periodPricing, @event.Operation);
            case nameof(TableType.PeriodPricingPax):
                var periodPricingPax = (Condtos)@event.Entity;
                return await HandlePeriodPricingPaxEventAsync(periodPricingPax, @event.Operation);
            case nameof(TableType.Regime):
                var regimen = (Restregi)@event.Entity;
                return await HandleRegimenEventAsync(regimen, @event.Operation);
            case nameof(TableType.Room):
                var room = (Resthabi)@event.Entity;
                return await HandleRoomEventAsync(room, @event.Operation);
            case nameof(TableType.ExtraTranslation):
                var extraTranslation = (Desextr)@event.Entity;
                return await HandleExtraTranslationEventAsync(extraTranslation, @event.Operation);
            case nameof(TableType.OfferAndSupplementTranslation):
                var offerAndSupplementTranslation = (Desofer)@event.Entity;
                return await HandleOfferAndSupplementTranslationEventAsync(offerAndSupplementTranslation, @event.Operation);
            case nameof(TableType.PaymentType):
                var paymentType = (Forpago)@event.Entity;
                return await HandlePaymentTypeEventAsync(paymentType, @event.Operation);
            case nameof(TableType.Tax):
                var tax = (Reszoim)@event.Entity;
                return await HandleTaxEventAsync(tax, @event.Operation);
            default:
                throw new InvalidOperationException($"Unsupported table type: {@event.Table}");
        }
    }

    private async Task<HttpResponseMessage> HandleCancellationPolicyLineEventAsync(Congasan congasan, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createCancellationPolicyLine.Execute(congasan),
            nameof(OperationType.Update) => await updateCancellationPolicyLine.Execute(congasan),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in CancellationPolicyLine"),
        };
    }

    private async Task<HttpResponseMessage> HandleClientEventAsync(Usureg client, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createClient.Execute(client),
            nameof(OperationType.Update) => await updateClient.Execute(client),
            nameof(OperationType.Delete) => await deleteClient.Execute(client),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Client"),
        };
    }

    private async Task<HttpResponseMessage> HandleClientTypeEventAsync(Restagen clientType, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createClientType.Execute(clientType),
            nameof(OperationType.Update) => await updateClientType.Execute(clientType),
            nameof(OperationType.Delete) => await deleteClientType.Execute(clientType),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in ClientType"),
        };
    }

    private async Task<HttpResponseMessage> HandleContractEventAsync(Concabec contract, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createContract.Execute(contract),
            nameof(OperationType.Update) => await updateContract.Execute(contract),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Contract"),
        };
    }

    private async Task<HttpResponseMessage> HandleExtraEventAsync(Conextra extra, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createExtra.Execute(extra),
            nameof(OperationType.Update) => await updateExtra.Execute(extra),
            nameof(OperationType.Delete) => await deleteExtra.Execute(extra),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Extra"),
        };
    }

    private async Task<HttpResponseMessage> HandleHotelEventAsync(Reshotel hotel, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createHotel.Execute(hotel),
            nameof(OperationType.Update) => await updateHotel.Execute(hotel),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Hotel"),
        };
    }

    private async Task<HttpResponseMessage> HandleHotelRoomConfigurationEventAsync(Resthaho hotelRoomConfiguration, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await pushHotelRoomConfiguration.Execute(hotelRoomConfiguration),
            nameof(OperationType.Update) => await pushHotelRoomConfiguration.Execute(hotelRoomConfiguration),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in HotelRoomConfiguration"),
        };
    }

    private async Task<HttpResponseMessage> HandleHotelSeasonEventAsync(Hotape hotelSeason, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await pushHotelSeason.Execute(hotelSeason),
            nameof(OperationType.Update) => await pushHotelSeason.Execute(hotelSeason),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in HotelSeason"),
        };
    }

    private async Task<HttpResponseMessage> HandleInventoryEventAsync(Resplaht inventory, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createInventory.Execute(inventory),
            nameof(OperationType.Update) => await updateInventory.Execute(inventory),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Inventory"),
        };
    }

    private async Task<HttpResponseMessage> HandleMarketEventAsync(Merca market, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createMarket.Execute(market),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Market"),
        };
    }

    private async Task<HttpResponseMessage> HandleMinimumStayEventAsync(Conestmi minimumStay, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createMinimumStay.Execute(minimumStay),
            nameof(OperationType.Update) => await updateMinimumStay.Execute(minimumStay),
            nameof(OperationType.Delete) => await deleteMinimumStay.Execute(minimumStay.Code),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in MinimumStay"),
        };
    }

    private async Task<HttpResponseMessage> HandleOccupancyRateEventAsync(Resthaco occupancyRate, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOccupancyRate.Execute(occupancyRate),
            nameof(OperationType.Update) => await updateOccupancyRate.Execute(occupancyRate),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OccupancyRate"),
        };
    }

    private async Task<HttpResponseMessage> HandleOfferAndSupplementEventAsync(Conofege offerAndSupplement, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOfferAndSupplement.Execute(offerAndSupplement),
            nameof(OperationType.Update) => await updateOfferAndSupplement.Execute(offerAndSupplement),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplement"),
        };
    }

    private async Task<HttpResponseMessage> HandleOfferAndSupplementConfigurationPaxEventAsync(Condtof offerAndSupplementConfigurationPax, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax),
            nameof(OperationType.Update) => await updateOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax),
            nameof(OperationType.Delete) => await deleteOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax.Code),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementConfigurationPax"),
        };
    }

    private async Task<HttpResponseMessage> HandleOfferAndSupplementGroupEventAsync(ConofcomHeader offerAndSupplementGroup, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOfferAndSupplementGroup.Execute(offerAndSupplementGroup),
            nameof(OperationType.Update) => await updateOfferAndSupplementGroup.Execute(offerAndSupplementGroup),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementGroup"),
        };
    }

    private async Task<HttpResponseMessage> HandleOfferAndSupplementGroupOfferAndSupplementEventAsync(ConofcomLine offerAndSupplementGroupOfferAndSupplement, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOfferAndSupplementGroupOfferAndSupplement.Execute(offerAndSupplementGroupOfferAndSupplement),
            nameof(OperationType.Delete) => await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(offerAndSupplementGroupOfferAndSupplement),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementGroupOfferAndSupplement"),
        };
    }

    private async Task<HttpResponseMessage> HandlePeriodPricingEventAsync(Conpreci periodPricing, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createPeriodPricing.Execute(periodPricing),
            nameof(OperationType.Update) => await updatePeriodPricing.Execute(periodPricing),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in PeriodPricing"),
        };
    }

    private async Task<HttpResponseMessage> HandlePeriodPricingPaxEventAsync(Condtos periodPricingPax, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createPeriodPricingPax.Execute(periodPricingPax),
            nameof(OperationType.Update) => await updatePeriodPricingPax.Execute(periodPricingPax),
            nameof(OperationType.Delete) => await deletePeriodPricingPax.Execute(periodPricingPax.Code),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in PeriodPricingPax"),
        };
    }

    private async Task<HttpResponseMessage> HandleRegimenEventAsync(Restregi regimen, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createRegimen.Execute(regimen),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Regimen"),
        };
    }

    private async Task<HttpResponseMessage> HandleRoomEventAsync(Resthabi room, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createRoom.Execute(room),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Room"),
        };
    }

    private async Task<HttpResponseMessage> HandleExtraTranslationEventAsync(Desextr extraTranslation, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createStaticExtraTranslation.Execute(extraTranslation),
            nameof(OperationType.Update) => await updateStaticExtraTranslation.Execute(extraTranslation),
            nameof(OperationType.Delete) => await deleteStaticExtraTranslation.Execute(extraTranslation),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in ExtraTranslation"),
        };
    }

    private async Task<HttpResponseMessage> HandleOfferAndSupplementTranslationEventAsync(Desofer offerAndSupplementTranslation, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createStaticOfferSupplementTranslation.Execute(offerAndSupplementTranslation),
            nameof(OperationType.Update) => await updateStaticOfferSupplementTranslation.Execute(offerAndSupplementTranslation),
            nameof(OperationType.Delete) => await deleteStaticOfferSupplementTranslation.Execute(offerAndSupplementTranslation),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementTranslation"),
        };
    }

    private async Task<HttpResponseMessage> HandlePaymentTypeEventAsync(Forpago paymentType, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createStaticPaymentType.Execute(paymentType),
            nameof(OperationType.Update) => await updateStaticPaymentType.Execute(paymentType),
            nameof(OperationType.Delete) => await deleteStaticPaymentType.Execute(paymentType),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in PaymentType"),
        };
    }

    private async Task<HttpResponseMessage> HandleTaxEventAsync(Reszoim tax, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createStaticTax.Execute(tax),
            nameof(OperationType.Update) => await updateStaticTax.Execute(tax),
            nameof(OperationType.Delete) => await deleteStaticTax.Execute(tax),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Tax"),
        };
    }
}
