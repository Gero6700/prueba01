using System.Net.Http.Json;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class AvailabilitySynchronizerApiClient : IAvailabilitySynchronizerApiClient {
    private readonly HttpClient httpClient;

    public AvailabilitySynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateCancellationPolicyLine(CancellationPolicyDto cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateClient(IntegrationDto client) {
        return httpClient.PutAsJsonAsync("api/v1/client/create", client);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateClientType(IntegrationClientTypeDto clientType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateContract(ContractHeaderDto contract) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateContractClient(IntegrationContractDto contractClient) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateExtra(ExtraDto extra) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateHotel(HotelDto hotel) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateHotelRoomConfiguration(HotelRoomConfigurationDto hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateInventory(InventoryDto inventory) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMarket(MarketDto market) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMarkupHotel(MarkupHotel markupHotel) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMinimumStay(MinimumStayDto minimumStay) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOccupancyRate(OccupancyRateDto occupancyRate) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferAndSupplement(OfferSupplementDto offerAndSupplement) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateRegime(MealDto regime) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateRoom(RoomDto room) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteClient(string clientCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteClientType(string ClientTypeCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteContract(string contractCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteContractClient(string contractClientCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteExtra(string extraCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteHotel(string hotelCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteHotelRoomConfiguration(HotelRoomConfigurationDto hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteInventory(InventoryDto inventory) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteMarket(string marketCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOccupancyRate(string code) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOfferAndSupplementConfigurationPax(string code) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOfferAndSupplementGroup(string code) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOfferAndSupplementGroupOfferAndSupplement(OfferAndSupplementGroupOfferAndSupplement offerAndSupplementGroupOfferAndSupplement) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeletePeriodPricingPax(string code) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteRoom(string roomCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateCancellationPolicyLine(CancellationPolicyDto cancellationPolicyLine) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateClient(IntegrationDto client) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateClientType(IntegrationClientTypeDto clientType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateContract(ContractHeaderDto contract) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateContractClient(IntegrationContractDto contractClient) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateExtra(ExtraDto extra) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateHotel(HotelDto hotel) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateHotelRoomConfiguration(HotelRoomConfigurationDto hotelRoomConfiguration) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateInventory(InventoryDto inventory) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateMarket(MarketDto market) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateMarkup(Markup markup) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateMinimumStay(MinimumStayDto minimumStay) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOccupancyRate(OccupancyRateDto occupancyRate) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferAndSupplement(OfferSupplementDto offerAndSupplement) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferAndSupplementConfigurationPax(OfferAndSupplementConfigurationPax offerAndSupplementConfigurationPax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferAndSupplementGroup(OfferAndSupplementGroup offerAndSupplementGroup) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdatePeriodPricing(PeriodPricing periodPricing) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdatePeriodPricingPax(PeriodPricingPax periodPricingPax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateRegime(MealDto regime) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateRoom(RoomDto room) {
        throw new NotImplementedException();
    }
}
