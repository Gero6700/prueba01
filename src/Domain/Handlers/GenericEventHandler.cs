namespace Senator.As400.Cloud.Sync.Application.Handlers;
public class GenericEventHandler(
    ICreateCancellationPolicyLine createCancellationPolicyLine,
    IUpdateCancellationPolicyLine updateCancellationPolicyLine,
    ICreateClient createClient,
    IUpdateClient updateClient,
    IDeleteClient deleteClient,
    ICreateClientType createClientType,
    IUpdateClientType updateClientType,
    IDeleteClientType deleteClientType,
    ICreateContract createContract,
    IUpdateContract updateContract,
    IDeleteContract deleteContract,
    ICreateExtra createExtra,
    IUpdateExtra updateExtra,
    IDeleteExtra deleteExtra,
    ICreateHotel createHotel,
    IUpdateHotel updateHotel,
    ICreateHotelRoomConfiguration createHotelRoomConfiguration,
    IUpdateHotelRoomConfiguration updateHotelRoomConfiguration,
    IDeleteHotelRoomConfiguration deleteHotelRoomConfiguration,
    ICreateInventory createInventory,
    IUpdateInventory updateInventory,
    IDeleteInventory deleteInventory,
    ICreateMarket createMarket,
    IUpdateMarket updateMarket,
    IDeleteMarket deleteMarket,
    ICreateMinimumStay createMinimumStay,
    IUpdateMinimumStay updateMinimumStay,
    ICreateOccupancyRate createOccupancyRate,
    IUpdateOccupancyRate updateOccupancyRate,
    IDeleteOccupancyRate deleteOccupancyRate,
    ICreateOfferAndSupplement createOfferAndSupplement,
    IUpdateOfferAndSupplement updateOfferAndSupplement,
    ICreateOfferAndSupplementConfigurationPax createOfferAndSupplementConfigurationPax,
    IUpdateOfferAndSupplementConfigurationPax updateOfferAndSupplementConfigurationPax,
    IDeleteOfferAndSupplementConfigurationPax deleteOfferAndSupplementConfigurationPax,
    ICreateOfferAndSupplementGroup createOfferAndSupplementGroup,
    IUpdateOfferAndSupplementGroup updateOfferAndSupplementGroup,
    IDeleteOfferAndSupplementGroup deleteOfferAndSupplementGroup,
    ICreateOfferAndSupplementGroupOfferAndSupplement createOfferAndSupplementGroupOfferAndSupplement,
    IDeleteOfferAndSupplementGroupOfferAndSupplement deleteOfferAndSupplementGroupOfferAndSupplement,
    ICreatePeriodPricing createPeriodPricing,
    IUpdatePeriodPricing updatePeriodPricing,
    ICreatePeriodPricingPax createPeriodPricingPax,
    IUpdatePeriodPricingPax updatePeriodPricingPax,
    IDeletePeriodPricingPax deletePeriodPricingPax,
    ICreateRegimen createRegimen,
    IUpdateRegimen updateRegimen
    ) : ISynchronizerHandler<GenericSynchronizationEvent> {
    private readonly ICreateCancellationPolicyLine createCancellationPolicyLine = createCancellationPolicyLine;
    private readonly IUpdateCancellationPolicyLine updateCancellationPolicyLine = updateCancellationPolicyLine;
    private readonly ICreateClient createClient = createClient;
    private readonly IUpdateClient updateClient = updateClient;
    private readonly IDeleteClient deleteClient = deleteClient;
    private readonly ICreateClientType createClientType = createClientType;
    private readonly IUpdateClientType updateClientType = updateClientType;
    private readonly IDeleteClientType deleteClientType = deleteClientType;
    private readonly ICreateContract createContract = createContract;
    private readonly IUpdateContract updateContract = updateContract;
    private readonly IDeleteContract deleteContract = deleteContract;
    private readonly ICreateExtra createExtra = createExtra;
    private readonly IUpdateExtra updateExtra = updateExtra;
    private readonly IDeleteExtra deleteExtra = deleteExtra;
    private readonly ICreateHotel createHotel = createHotel;
    private readonly IUpdateHotel updateHotel = updateHotel;
    private readonly ICreateHotelRoomConfiguration createHotelRoomConfiguration = createHotelRoomConfiguration;
    private readonly IUpdateHotelRoomConfiguration updateHotelRoomConfiguration = updateHotelRoomConfiguration;
    private readonly IDeleteHotelRoomConfiguration deleteHotelRoomConfiguration = deleteHotelRoomConfiguration;
    private readonly ICreateInventory createInventory = createInventory;
    private readonly IUpdateInventory updateInventory = updateInventory;
    private readonly IDeleteInventory deleteInventory = deleteInventory;
    private readonly ICreateMarket createMarket = createMarket;
    private readonly IUpdateMarket updateMarket = updateMarket;
    private readonly IDeleteMarket deleteMarket = deleteMarket;
    private readonly ICreateMinimumStay createMinimumStay = createMinimumStay;
    private readonly IUpdateMinimumStay updateMinimumStay = updateMinimumStay;
    private readonly ICreateOccupancyRate createOccupancyRate = createOccupancyRate;
    private readonly IUpdateOccupancyRate updateOccupancyRate = updateOccupancyRate;
    private readonly ICreateOfferAndSupplement createOfferAndSupplement = createOfferAndSupplement;
    private readonly IUpdateOfferAndSupplement updateOfferAndSupplement = updateOfferAndSupplement;
    private readonly ICreateOfferAndSupplementConfigurationPax createOfferAndSupplementConfigurationPax = createOfferAndSupplementConfigurationPax;
    private readonly IUpdateOfferAndSupplementConfigurationPax updateOfferAndSupplementConfigurationPax = updateOfferAndSupplementConfigurationPax;
    private readonly IDeleteOfferAndSupplementConfigurationPax deleteOfferAndSupplementConfigurationPax = deleteOfferAndSupplementConfigurationPax;
    private readonly ICreateOfferAndSupplementGroup createOfferAndSupplementGroup = createOfferAndSupplementGroup;
    private readonly IUpdateOfferAndSupplementGroup updateOfferAndSupplementGroup = updateOfferAndSupplementGroup;
    private readonly IDeleteOfferAndSupplementGroup deleteOfferAndSupplementGroup = deleteOfferAndSupplementGroup;
    private readonly ICreateOfferAndSupplementGroupOfferAndSupplement createOfferAndSupplementGroupOfferAndSupplement = createOfferAndSupplementGroupOfferAndSupplement;
    private readonly IDeleteOfferAndSupplementGroupOfferAndSupplement deleteOfferAndSupplementGroupOfferAndSupplement = deleteOfferAndSupplementGroupOfferAndSupplement;
    private readonly ICreatePeriodPricing createPeriodPricing = createPeriodPricing;
    private readonly IUpdatePeriodPricing updatePeriodPricing = updatePeriodPricing;
    private readonly ICreatePeriodPricingPax createPeriodPricingPax = createPeriodPricingPax;
    private readonly IUpdatePeriodPricingPax updatePeriodPricingPax = updatePeriodPricingPax;
    private readonly IDeletePeriodPricingPax deletePeriodPricingPax = deletePeriodPricingPax;
    private readonly ICreateRegimen createRegimen = createRegimen;
    private readonly IUpdateRegimen updateRegimen = updateRegimen;

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
            case nameof(TableType.Regimen):
                var regimen = (Restregi)@event.Entity;
                return await HandleRegimenEventAsync(regimen, @event.Operation);
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
            nameof(OperationType.Create) => await createHotelRoomConfiguration.Execute(hotelRoomConfiguration),
            nameof(OperationType.Update) => await updateHotelRoomConfiguration.Execute(hotelRoomConfiguration),
            nameof(OperationType.Delete) => await deleteHotelRoomConfiguration.Execute(hotelRoomConfiguration),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in HotelRoomConfiguration"),
        };
    }

    private async Task<HttpResponseMessage> HandleInventoryEventAsync(Resplaht inventory, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createInventory.Execute(inventory),
            nameof(OperationType.Update) => await updateInventory.Execute(inventory),
            nameof(OperationType.Delete) => await deleteInventory.Execute(inventory),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Inventory"),
        };
    }

    private async Task<HttpResponseMessage> HandleMarketEventAsync(Merca market, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createMarket.Execute(market),
            nameof(OperationType.Update) => await updateMarket.Execute(market),
            nameof(OperationType.Delete) => await deleteMarket.Execute(market),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Market"),
        };
    }

    private async Task<HttpResponseMessage> HandleMinimumStayEventAsync(Conestmi minimumStay, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createMinimumStay.Execute(minimumStay),
            nameof(OperationType.Update) => await updateMinimumStay.Execute(minimumStay),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in MinimumStay"),
        };
    }

    private async Task<HttpResponseMessage> HandleOccupancyRateEventAsync(Resthaco occupancyRate, string operation) {
        return operation switch {
            nameof(OperationType.Create) => await createOccupancyRate.Execute(occupancyRate),
            nameof(OperationType.Update) => await updateOccupancyRate.Execute(occupancyRate),
            nameof(OperationType.Delete) => await deleteOccupancyRate.Execute(occupancyRate.Cocod),
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
            nameof(OperationType.Delete) => await deleteOfferAndSupplementGroup.Execute(offerAndSupplementGroup),
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
            nameof(OperationType.Update) => await updateRegimen.Execute(regimen),
            _ => throw new InvalidOperationException($"Unsupported operation: {operation} in Regimen"),
        };
    }
}
