using System.Net.Http.Json;
namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class AvailabilitySynchronizerApiClient : IAvailabilitySynchronizerApiClient {
    private readonly HttpClient httpClient = new();

    public AvailabilitySynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<Response> CreateCancellationPolicyLine(CancellationPolicyLine cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateClient(Client client) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateClientType(ClientType clientType) {
        throw new NotImplementedException();
    }

    public async Task<Response> CreateContract(Contract contract) {
        var response = await httpClient.PostAsJsonAsync("api/contracts", contract);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Response>();
    }

    public Task<Response> CreateContractClient(ContractClient contractClient) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateExtra(Extra extra) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateHotel(Dtos.BookingCenter.Availability.Hotel hotel) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateMarket(Market market) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateMarkupHotel(MarkupHotel markupHotel) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateMinimumStay(MinimumStay minimumStay) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateOccupancyRate(OccupancyRate occupancyRate) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateOfferAndSupplement(OfferAndSupplement offerAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<Response> CreatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    public Task<Response> CreatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateRegime(Dtos.BookingCenter.Availability.Regime regime) {
        throw new NotImplementedException();
    }

    public Task<Response> CreateRoom(Dtos.BookingCenter.Availability.Room room) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteClient(string clientCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteClientType(string ClientTypeCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteContract(string contractCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteContractClient(string contractClientCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteExtra(string extraCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteHotel(string hotelCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteMarket(string marketCode) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteOccupancyRate(string code) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteOfferAndSupplementConfigurationPax(string code) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteOfferAndSupplementGroup(string code) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<Response> DeletePeriodPricingPax(string code) {
        throw new NotImplementedException();
    }

    public Task<Response> DeleteRoom(string roomCode) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateCancellationPolicyLine(CancellationPolicyLine cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateClient(Client client) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateClientType(ClientType clientType) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateContract(Contract contract) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateContractClient(ContractClient contractClient) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateExtra(Extra extra) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateHotel(Dtos.BookingCenter.Availability.Hotel hotel) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateHotelRoomConfiguration(HotelRoomConfiguration hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateInventory(Inventory inventory) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateMarket(Market market) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateMinimumStay(MinimumStay minimumStay) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateOccupancyRate(OccupancyRate occupancyRate) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateOfferAndSupplement(OfferAndSupplement offerAndSupplement) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateRegime(Dtos.BookingCenter.Availability.Regime regime) {
        throw new NotImplementedException();
    }

    public Task<Response> UpdateRoom(Dtos.BookingCenter.Availability.Room room) {
        throw new NotImplementedException();
    }
}
