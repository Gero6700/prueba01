using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricing;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;

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
    ) : IEventHandler<GenericNotificationEvent> {
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

    public async Task HandleAsync(GenericNotificationEvent @event) {
        switch (@event.Table) {
            case nameof(TableType.CancellationPolicyLine):
                var cancellationPolicyLine = (Congasan)@event.Entity;
                await HandleCancellationPolicyLineEventAsync(cancellationPolicyLine, @event.Operation);
                break;
            case nameof(TableType.Client):
                var client = (Usureg)@event.Entity;
                await HandleClientEventAsync(client, @event.Operation);
                break;
            case nameof(TableType.ClientType):
                var clientType = (Restagen)@event.Entity;
                await HandleClientTypeEventAsync(clientType, @event.Operation);
                break;
            case nameof(TableType.Contract):
                var contract = (Concabec)@event.Entity;
                await HandleContractEventAsync(contract, @event.Operation);
                break;
            case nameof(TableType.Extra):
                var extra = (Conextra)@event.Entity;
                await HandleExtraEventAsync(extra, @event.Operation);
                break;
            case nameof(TableType.Hotel):
                var hotel = (Reshotel)@event.Entity;
                await HandleHotelEventAsync(hotel, @event.Operation);
                break;
            case nameof(TableType.HotelRoomConfiguration):
                var hotelRoomConfiguration = (Resthaho)@event.Entity;
                await HandleHotelRoomConfigurationEventAsync(hotelRoomConfiguration, @event.Operation);
                break;
            case nameof(TableType.Inventory):
                var inventory = (Resplaht)@event.Entity;
                await HandleInventoryEventAsync(inventory, @event.Operation);
                break;
            case nameof(TableType.Market):
                var market = (Merca)@event.Entity;
                await HandleMarketEventAsync(market, @event.Operation);
                break;
            case nameof(TableType.MinimumStay):
                var minimumStay = (Conestmi)@event.Entity;
                await HandleMinimumStayEventAsync(minimumStay, @event.Operation);
                break;
            case nameof(TableType.OccupancyRate):
                var occupancyRate = (Resthaco)@event.Entity;
                await HandleOccupancyRateEventAsync(occupancyRate, @event.Operation);
                break;
            case nameof(TableType.OfferAndSupplement):
                var offerAndSupplement = (Conofege)@event.Entity;
                await HandleOfferAndSupplementEventAsync(offerAndSupplement, @event.Operation);
                break;
            case nameof(TableType.OfferAndSupplementConfigurationPax):
                var offerAndSupplementConfigurationPax = (Condtof)@event.Entity;
                await HandleOfferAndSupplementConfigurationPaxEventAsync(offerAndSupplementConfigurationPax, @event.Operation);
                break;
            case nameof(TableType.OfferAndSupplementGroup):
                var offerAndSupplementGroup = (ConofcomHeader)@event.Entity;
                await HandleOfferAndSupplementGroupEventAsync(offerAndSupplementGroup, @event.Operation);
                break;
            case nameof(TableType.OfferAndSupplementGroupOfferAndSupplement):
                var offerAndSupplementGroupOfferAndSupplement = (ConofcomLine)@event.Entity;
                await HandleOfferAndSupplementGroupOfferAndSupplementEventAsync(offerAndSupplementGroupOfferAndSupplement, @event.Operation);
                break;
            case nameof(TableType.PeriodPricing):
                var periodPricing = (Conpreci)@event.Entity;
                await HandlePeriodPricingEventAsync(periodPricing, @event.Operation);
                break;
            case nameof(TableType.PeriodPricingPax):
                var periodPricingPax = (Condtos)@event.Entity;
                await HandlePeriodPricingPaxEventAsync(periodPricingPax, @event.Operation);
                break;
            case nameof(TableType.Regimen):
                var regimen = (Restregi)@event.Entity;
                await HandleRegimenEventAsync(regimen, @event.Operation);
                break;
            default:
                throw new InvalidOperationException($"Unsupported table type: {@event.Table}");
        }
    }

    private async Task HandleCancellationPolicyLineEventAsync(Congasan congasan, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createCancellationPolicyLine.Execute(congasan);
                break;
            case nameof(OperationType.Update):
                await updateCancellationPolicyLine.Execute(congasan);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in CancellationPolicyLine");
        }
    }

    private async Task HandleClientEventAsync(Usureg client, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createClient.Execute(client);
                break;
            case nameof(OperationType.Update):
                await updateClient.Execute(client);
                break;
            case nameof(OperationType.Delete):
                await deleteClient.Execute(client);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Client");
        }
    }

    private async Task HandleClientTypeEventAsync(Restagen clientType, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createClientType.Execute(clientType);
                break;
            case nameof(OperationType.Update):
                await updateClientType.Execute(clientType);
                break;
            case nameof(OperationType.Delete):
                await deleteClientType.Execute(clientType);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in ClientType");
        }
    }

    private async Task HandleContractEventAsync(Concabec contract, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createContract.Execute(contract);
                break;
            case nameof(OperationType.Update):
                await updateContract.Execute(contract);
                break;
            case nameof(OperationType.Delete):
                await deleteContract.Execute(contract.ContractCode);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Contract");
        }
    }

    private async Task HandleExtraEventAsync(Conextra extra, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createExtra.Execute(extra);
                break;
            case nameof(OperationType.Update):
                await updateExtra.Execute(extra);
                break;
            case nameof(OperationType.Delete):
                await deleteExtra.Execute(extra);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Extra");
        }
    }

    private async Task HandleHotelEventAsync(Reshotel hotel, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createHotel.Execute(hotel);
                break;
            case nameof(OperationType.Update):
                await updateHotel.Execute(hotel);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in table Hotel");
        }
    }

    private async Task HandleHotelRoomConfigurationEventAsync(Resthaho hotelRoomConfiguration, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createHotelRoomConfiguration.Execute(hotelRoomConfiguration);
                break;
            case nameof(OperationType.Update):
                await updateHotelRoomConfiguration.Execute(hotelRoomConfiguration);
                break;
            case nameof(OperationType.Delete):
                await deleteHotelRoomConfiguration.Execute(hotelRoomConfiguration);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in HotelRoomConfiguration");
        }
    }

    private async Task HandleInventoryEventAsync(Resplaht inventory, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createInventory.Execute(inventory);
                break;
            case nameof(OperationType.Update):
                await updateInventory.Execute(inventory);
                break;
            case nameof(OperationType.Delete):
                await deleteInventory.Execute(inventory);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Inventory");
        }
    }

    private async Task HandleMarketEventAsync(Merca market, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createMarket.Execute(market);
                break;
            case nameof(OperationType.Update):
                await updateMarket.Execute(market);
                break;
            case nameof(OperationType.Delete):
                await deleteMarket.Execute(market);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Market");
        }
    }

    private async Task HandleMinimumStayEventAsync(Conestmi minimumStay, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createMinimumStay.Execute(minimumStay);
                break;
            case nameof(OperationType.Update):
                await updateMinimumStay.Execute(minimumStay);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in MinimumStay");
        }
    }

    private async Task HandleOccupancyRateEventAsync(Resthaco occupancyRate, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createOccupancyRate.Execute(occupancyRate);
                break;
            case nameof(OperationType.Update):
                await updateOccupancyRate.Execute(occupancyRate);
                break;
            case nameof(OperationType.Delete):
                await deleteOccupancyRate.Execute(occupancyRate.Cocod);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in OccupancyRate");
        }
    }

    private async Task HandleOfferAndSupplementEventAsync(Conofege offerAndSupplement, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createOfferAndSupplement.Execute(offerAndSupplement);
                break;
            case nameof(OperationType.Update):
                await updateOfferAndSupplement.Execute(offerAndSupplement);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplement");
        }
    }

    private async Task HandleOfferAndSupplementConfigurationPaxEventAsync(Condtof offerAndSupplementConfigurationPax, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax);
                break;
            case nameof(OperationType.Update):
                await updateOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax);
                break;
            case nameof(OperationType.Delete):
                await deleteOfferAndSupplementConfigurationPax.Execute(offerAndSupplementConfigurationPax.Code);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementConfigurationPax");
        }
    }

    private async Task HandleOfferAndSupplementGroupEventAsync(ConofcomHeader offerAndSupplementGroup, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createOfferAndSupplementGroup.Execute(offerAndSupplementGroup);
                break;
            case nameof(OperationType.Update):
                await updateOfferAndSupplementGroup.Execute(offerAndSupplementGroup);
                break;
            case nameof(OperationType.Delete):
                await deleteOfferAndSupplementGroup.Execute(offerAndSupplementGroup);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementGroup");
        }
    }

    private async Task HandleOfferAndSupplementGroupOfferAndSupplementEventAsync(ConofcomLine offerAndSupplementGroupOfferAndSupplement, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createOfferAndSupplementGroupOfferAndSupplement.Execute(offerAndSupplementGroupOfferAndSupplement);
                break;
            case nameof(OperationType.Delete):
                await deleteOfferAndSupplementGroupOfferAndSupplement.Execute(offerAndSupplementGroupOfferAndSupplement);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in OfferAndSupplementGroupOfferAndSupplement");
        }
    }

    private async Task HandlePeriodPricingEventAsync(Conpreci periodPricing, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createPeriodPricing.Execute(periodPricing);
                break;
            case nameof(OperationType.Update):
                await updatePeriodPricing.Execute(periodPricing);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in PeriodPricing");
        }
    }

    private async Task HandlePeriodPricingPaxEventAsync(Condtos periodPricingPax, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createPeriodPricingPax.Execute(periodPricingPax);
                break;
            case nameof(OperationType.Update):
                await updatePeriodPricingPax.Execute(periodPricingPax);
                break;
            case nameof(OperationType.Delete):
                await deletePeriodPricingPax.Execute(periodPricingPax.Code);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in PeriodPricingPax");
        }
    }

    private async Task HandleRegimenEventAsync(Restregi regimen, string operation) {
        switch (operation) {
            case nameof(OperationType.Create):
                await createRegimen.Execute(regimen);
                break;
            case nameof(OperationType.Update):
                await updateRegimen.Execute(regimen);
                break;
            default:
                throw new InvalidOperationException($"Unsupported operation: {operation} in Regimen");
        }
    }
}
