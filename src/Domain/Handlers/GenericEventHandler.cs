using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;

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
    IUpdateMinimumStay updateMinimumStay
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
}
