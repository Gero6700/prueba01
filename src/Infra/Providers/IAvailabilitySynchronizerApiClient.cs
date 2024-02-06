using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers {
    public interface IAvailabilitySynchronizerApiClient {
        Task<Response> CreateContract(Contract contract);
        Task<Response> CreateContractClient(ContractClient contractClient);
        Task<Response> UpdateContract(Contract contract);
        Task<Response> UpdateContractClient(ContractClient contractClient);
        Task<Response> DeleteContract(string codContract);
        Task<Response> CreateClient(Client client);
        Task<Response> UpdateClient(Client client);
        Task<Response> DeleteClient(string codClient);
        Task<Response> CreateClientType(ClientType clientType);
        Task<Response> UpdateClientType(ClientType clientType);
        Task<Response> DeleteClientType(string codClientType);
        Task<Response> CreateHotel(Hotel hotel);
        Task<Response> UpdateHotel(Hotel hotel);
        Task<Response> DeleteHotel(string codHotel);
        Task<Response> CreateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> UpdateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> DeleteHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> CreateMarket(Market market);
        Task<Response> UpdateMarket(Market market);
        Task<Response> DeleteMarket(Market market);
        Task<Response> CreateInventory(Inventory inventory);
        Task<Response> UpdateInventory(Inventory inventory);
        Task<Response> DeleteInventory(Inventory inventory);
        Task<Response> CreateRoom(Room room);


    }
}
