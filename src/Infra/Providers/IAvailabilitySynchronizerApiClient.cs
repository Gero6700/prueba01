using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers {
    public interface IAvailabilitySynchronizerApiClient {
        Task<Response> CreateContract(Contract contract);
        Task<Response> CreateContractClient(ContractClient contractClient);
        Task<Response> UpdateContract(Contract contract);
        Task<Response> UpdateContractClient(ContractClient contractClient);
        Task<Response> DeleteContract(string contractCode);
        Task<Response> CreateClient(Client client);
        Task<Response> UpdateClient(Client client);
        Task<Response> DeleteClient(string clientCode);
        Task<Response> CreateClientType(ClientType clientType);
        Task<Response> UpdateClientType(ClientType clientType);
        Task<Response> DeleteClientType(string ClientTypeCode);
        Task<Response> CreateHotel(Hotel hotel);
        Task<Response> UpdateHotel(Hotel hotel);
        Task<Response> DeleteHotel(string hotelCode);
        Task<Response> CreateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> UpdateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> DeleteHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration);
        Task<Response> CreateMarket(Market market);
        Task<Response> UpdateMarket(Market market);
        Task<Response> DeleteMarket(string marketCode);
        Task<Response> CreateInventory(Inventory inventory);
        Task<Response> UpdateInventory(Inventory inventory);
        Task<Response> DeleteInventory(Inventory inventory);
        Task<Response> CreateRoom(Room room);
        Task<Response> UpdateRoom(Room room);
        Task<Response> DeleteRoom(string roomCode);
        Task<Response> CreateExtra(Extra extra);
        Task<Response> UpdateExtra(Extra extra);
        Task<Response> CreateMinimumStay(MinimumStay minimumStay);
        Task<Response> UpdateMinimumStay(MinimumStay minimumStay);
        Task<Response> CreateRegime(Regime regime);
        Task<Response> UpdateRegime(Regime regime);
    }
}
