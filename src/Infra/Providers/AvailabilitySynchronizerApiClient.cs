using System.Net.Http.Json;
namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class AvailabilitySynchronizerApiClient : IAvailabilitySynchronizerApiClient {
    private readonly HttpClient httpClient = new();

    public AvailabilitySynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<HttpResponseMessage> CreateCancellationPolicyLine(CancellationPolicyLine cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateClient(Client client) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateClientType(ClientType clientType) {
        throw new NotImplementedException();
    }

    public async Task<HttpResponseMessage> CreateContract(Contract contract) {
        return await httpClient.PostAsJsonAsync("api/v1/contractheader/create", contract);
    }

    public async Task<HttpResponseMessage> UpdateContract(Contract contract) {
        return await httpClient.PutAsJsonAsync("api/v1/contractheader/update", contract);
    }

    public async Task<HttpResponseMessage> CreateContractClient(ContractClient contractClient) {
        return await httpClient.PostAsJsonAsync("api/create-contract-client", contractClient);
    }
   

    public Task<HttpResponseMessage> UpdateContractClient(ContractClient contractClient) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateExtra(Extra extra) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateHotel(Dtos.BookingCenter.Availability.Hotel hotel) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateMarket(Market market) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateMarkupHotel(MarkupHotel markupHotel) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateMinimumStay(MinimumStay minimumStay) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateOccupancyRate(OccupancyRate occupancyRate) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateOfferAndSupplement(OfferAndSupplement offerAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateRegime(Dtos.BookingCenter.Availability.Regime regime) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> CreateRoom(Dtos.BookingCenter.Availability.Room room) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteClient(string clientCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteClientType(string ClientTypeCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteContract(string contractCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteContractClient(string contractClientCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteExtra(string extraCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteHotel(string hotelCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteMarket(string marketCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteOccupancyRate(string code) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteOfferAndSupplementConfigurationPax(string code) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteOfferAndSupplementGroup(string code) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeletePeriodPricingPax(string code) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeleteRoom(string roomCode) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateCancellationPolicyLine(CancellationPolicyLine cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateClient(Client client) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateClientType(ClientType clientType) {
        throw new NotImplementedException();
    }

    //public Task<HttpResponseMessage> UpdateContract(Contract contract) {
    //    throw new NotImplementedException();
    //}

    //public Task<HttpResponseMessage> UpdateContractClient(ContractClient contractClient) {
    //    throw new NotImplementedException();
    //}

    public Task<HttpResponseMessage> UpdateExtra(Extra extra) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateHotel(Dtos.BookingCenter.Availability.Hotel hotel) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateMarket(Market market) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateMinimumStay(MinimumStay minimumStay) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateOccupancyRate(OccupancyRate occupancyRate) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateOfferAndSupplement(OfferAndSupplement offerAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateRegime(Dtos.BookingCenter.Availability.Regime regime) {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> UpdateRoom(Dtos.BookingCenter.Availability.Room room) {
        throw new NotImplementedException();
    }
}
