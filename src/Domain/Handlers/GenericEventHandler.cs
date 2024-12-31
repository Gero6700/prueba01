namespace Senator.As400.Cloud.Sync.Application.Handlers;
public class GenericEventHandler : IEventHandler<NotificationEvent> {
    private readonly ICreateClient createClient;
    private readonly IUpdateClient updateClient;
    private readonly ICreateContract createContract;
    private readonly IUpdateContract updateContract;
    private readonly IDeleteContract deleteContract;
    private readonly ICreateHotel createHotel;
    private readonly IUpdateHotel updateHotel;

    public GenericEventHandler(
        ICreateClient createClient,
        IUpdateClient updateClient,
        ICreateContract createContract,
        IUpdateContract updateContract,
        IDeleteContract deleteContract,
        ICreateHotel createHotel,
        IUpdateHotel updateHotel) {
        this.createClient = createClient;
        updateClient = updateClient;
        this.createContract = createContract;
        this.updateContract = updateContract;
        this.deleteContract = deleteContract;
        this.createHotel = createHotel;
        this.updateHotel = updateHotel;
    }

    public async Task HandleAsync(NotificationEvent @event) {
        switch (@event.Table) {
            case nameof(TableType.Client):
                var client = (Usureg)@event.Entity;
                await HandleClientEventAsync(client, @event.Operation);
                break;
            case nameof(TableType.Contract):
                var contract = (Concabec)@event.Entity;
                await HandleContractEventAsync(contract, @event.Operation);
                break;
            case nameof(TableType.Hotel):
                var hotel = (Reshotel)@event.Entity;
                await HandleHotelEventAsync(hotel, @event.Operation);
                break;
               
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
        }
    }
}
