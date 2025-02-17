using System.Net.Http.Json;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class AvailabilitySynchronizerApiClient : IAvailabilitySynchronizerApiClient {
    private readonly HttpClient httpClient;

    public AvailabilitySynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateCancellationPolicy(CancellationPolicyDto cancellationPolicy) {
        return httpClient.PostAsJsonAsync("api/v1/CancellationPolicy/create", cancellationPolicy);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateCommission(CommissionDto commission) {
        return httpClient.PostAsJsonAsync("api/v1/Commission/create", commission);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateContractHeader(ContractHeaderDto contractHeader) {
        return httpClient.PostAsJsonAsync("api/v1/ContractHeader/create", contractHeader);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateExtra(ExtraDto extra) {
        return httpClient.PostAsJsonAsync("api/v1/Extra/create", extra);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateHotel(HotelDto hotel) {
        return httpClient.PostAsJsonAsync("api/v1/Hotel/create", hotel);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateIntegration(IntegrationDto integration) {
        return httpClient.PostAsJsonAsync("api/v1/Integration/create", integration);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateIntegrationClientType(IntegrationClientTypeDto integrationClientType) {
        return httpClient.PostAsJsonAsync("api/v1/IntegrationClientType/create", integrationClientType);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateIntegrationContract(IntegrationContractDto integrationContract) {
        return httpClient.PostAsJsonAsync("api/v1/IntegrationContract/create", integrationContract);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateInventory(InventoryDto inventory) {
        return httpClient.PostAsJsonAsync("api/v1/Inventory/create", inventory);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMarket(MarketDto market) {
        return httpClient.PostAsJsonAsync("api/v1/Market/create", market);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMeal(MealDto meal) {
        return httpClient.PostAsJsonAsync("api/v1/Meal/create", meal);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateMinimumStay(MinimumStayDto minimumStay) {
        return httpClient.PostAsJsonAsync("api/v1/MinimumStay/create", minimumStay);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOccupancyRate(OccupancyRateDto occupancyRate) {
        return httpClient.PostAsJsonAsync("api/v1/OccupancyRate/create", occupancyRate);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferSupplement(OfferSupplementDto offerSupplement) {
        return httpClient.PostAsJsonAsync("api/v1/OfferSupplement/create", offerSupplement);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferSupplementConfigurationPax(OfferSupplementConfigurationPaxDto offerSupplementConfigurationPax) {
        return httpClient.PostAsJsonAsync("api/v1/OfferSupplementConfigurationPax/create", offerSupplementConfigurationPax);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferSupplementGroup(OfferSupplementGroupDto offerSupplementGroup) {
        return httpClient.PostAsJsonAsync("api/v1/OfferSupplementGroup/create", offerSupplementGroup);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateOfferSupplementGroupRelation(OfferSupplementGroupRelationDto offerSupplementGroupRelation) {
        return httpClient.PostAsJsonAsync("api/v1/OfferSupplementGroupRelation/create", offerSupplementGroupRelation);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreatePeriodPricing(PeriodPricingDto periodPricing) {
        return httpClient.PostAsJsonAsync("api/v1/PeriodPricing/create", periodPricing);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreatePeriodPricingPax(PeriodPricingPaxDto periodPricingPax) {
        return httpClient.PostAsJsonAsync("api/v1/PeriodPricingPax/create", periodPricingPax);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.CreateRoom(RoomDto room) {
        return httpClient.PostAsJsonAsync("api/v1/Room/create", room);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteCommission(string code) {
        return httpClient.DeleteAsync($"api/v1/Commission/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteIntegration(string code) {
        return httpClient.DeleteAsync($"api/v1/Integration/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteIntegrationClientType(string code) {
        return httpClient.DeleteAsync($"api/v1/IntegrationClientType/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteMinimunStay(string code) {
        return httpClient.DeleteAsync($"api/v1/MinimumStay/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOfferSupplementConfigurationPax(string code) {
        return httpClient.DeleteAsync($"api/v1/OfferSupplementConfigurationPax/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeleteOfferSupplementGroupRelation(OfferSupplementGroupRelationDto offerSupplementGroupRelation) {
        return httpClient.DeleteAsync($"api/v1/OfferSupplementGroupRelation/delete/{offerSupplementGroupRelation}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.DeletePeriodPricingPax(string code) {
        return httpClient.DeleteAsync($"api/v1/PeriodPricingPax/delete/{code}");
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.PushHotelRoomConfiguration(HotelRoomConfigurationDto hotelRoomConfiguration) {
        return httpClient.PostAsJsonAsync("api/v1/HotelRoomConfiguration/push", hotelRoomConfiguration);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.PushHotelSeasons(HotelSeasonsDto hotelSeasons) {
        return httpClient.PostAsJsonAsync("api/v1/HotelSeason/push", hotelSeasons);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.PushOccupancyScore(OccupancyScoreDto occupancyScore) {
        return httpClient.PostAsJsonAsync("api/v1/OccupancyScore/push", occupancyScore);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateCancellationPolicy(CancellationPolicyDto cancellationPolicy) {
        return httpClient.PutAsJsonAsync("api/v1/CancellationPolicy/update", cancellationPolicy);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateCommission(CommissionDto commission) {
        return httpClient.PutAsJsonAsync("api/v1/Commission/update", commission);   
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateContractHeader(ContractHeaderDto contractHeader) {
        return httpClient.PutAsJsonAsync("api/v1/ContractHeader/update", contractHeader);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateExtra(ExtraDto extra) {
        return httpClient.PutAsJsonAsync("api/v1/Extra/update", extra);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateHotel(HotelDto hotel) {
        return httpClient.PutAsJsonAsync("api/v1/Hotel/update", hotel);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateIntegration(IntegrationDto integration) {
        return httpClient.PutAsJsonAsync("api/v1/Integration/update", integration);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateIntegrationClientType(IntegrationClientTypeDto integrationClientType) {
        return httpClient.PutAsJsonAsync("api/v1/IntegrationClientType/update", integrationClientType);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateIntegrationContract(IntegrationContractDto integrationContract) {
        return httpClient.PutAsJsonAsync("api/v1/IntegrationContract/update", integrationContract);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateInventory(InventoryDto inventory) {
        return httpClient.PutAsJsonAsync("api/v1/Inventory/update", inventory);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateMinimumStay(MinimumStayDto minimumStay) {
        return httpClient.PutAsJsonAsync("api/v1/MinimumStay/update", minimumStay);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOccupancyRate(OccupancyRateDto occupancyRate) {
        return httpClient.PutAsJsonAsync("api/v1/OccupancyRate/update", occupancyRate);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferSupplement(OfferSupplementDto offerSupplement) {
        return httpClient.PutAsJsonAsync("api/v1/OfferSupplement/update", offerSupplement);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferSupplementConfigurationPax(OfferSupplementConfigurationPaxDto offerSupplementConfigurationPax) {
        return httpClient.PutAsJsonAsync("api/v1/OfferSupplementConfigurationPax/update", offerSupplementConfigurationPax);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdateOfferSupplementGroup(OfferSupplementGroupDto offerSupplementGroup) {
        return httpClient.PutAsJsonAsync("api/v1/OfferSupplementGroup/update", offerSupplementGroup);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdatePeriodPricing(PeriodPricingDto periodPricing) {
        return httpClient.PutAsJsonAsync("api/v1/PeriodPricing/update", periodPricing);
    }

    Task<HttpResponseMessage> IAvailabilitySynchronizerApiClient.UpdatePeriodPricingPax(PeriodPricingPaxDto periodPricingPax) {
        return httpClient.PutAsJsonAsync("api/v1/PeriodPricingPax/update", periodPricingPax);
    }
}
