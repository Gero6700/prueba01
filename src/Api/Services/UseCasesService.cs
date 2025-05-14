namespace Senator.As400.Cloud.Sync.Api.Services;
public static class UseCasesService {
    public static IServiceCollection AddUseCases(this IServiceCollection services) {
        services.AddSingleton<ICreateCancellationPolicy, CreateCancellationPolicy>();
        services.AddSingleton<IUpdateCancellationPolicy, UpdateCancellationPolicy>();

        services.AddSingleton<ICreateIntegrationClientType, CreateIntegrationClientType>();
        services.AddSingleton<IUpdateIntegrationClientType, UpdateIntegrationClientType>();
        services.AddSingleton<IDeleteIntegrationClientType, DeleteIntegrationClientType>();

        services.AddSingleton<ICreateIntegration, CreateIntegration>();
        services.AddSingleton<IUpdateIntegration, UpdateIntegration>();
        services.AddSingleton<IDeleteIntegration, DeleteIntegration>();

        services.AddSingleton<ICreateContractHeader, CreateContractHeader>();
        services.AddSingleton<IUpdateContractHeader, UpdateContractHeader>();

        services.AddSingleton<ICreateExtra, CreateExtra>();
        services.AddSingleton<IUpdateExtra, UpdateExtra>();
        services.AddSingleton<IDeleteExtra, DeleteExtra>();

        services.AddSingleton<ICreateHotel, CreateHotel>();
        services.AddSingleton<IUpdateHotel, UpdateHotel>();

        services.AddSingleton<IPushHotelRoomConfiguration, PushHotelRoomConfiguration>();
        services.AddSingleton<IPushHotelSeason, PushHotelSeason>();

        services.AddSingleton<ICreateInventory, CreateInventory>();
        services.AddSingleton<IUpdateInventory, UpdateInventory>();

        services.AddSingleton<ICreateMarket, CreateMarket>();

        services.AddSingleton<ICreateMinimumStay, CreateMinimumStay>();
        services.AddSingleton<IUpdateMinimumStay, UpdateMinimumStay>();
        services.AddSingleton<IDeleteMinimumStay, DeleteMinimumStay>();

        services.AddSingleton<ICreateOccupancyRate, CreateOccupancyRate>();
        services.AddSingleton<IUpdateOccupancyRate, UpdateOccupancyRate>();

        services.AddSingleton<ICreateOfferSupplement, CreateOfferSupplement>();
        services.AddSingleton<IUpdateOfferSupplement, UpdateOfferSupplement>();

        services.AddSingleton<ICreateOfferSupplementConfigurationPax, CreateOfferSupplementConfigurationPax>();
        services.AddSingleton<IUpdateOfferSupplementConfigurationPax, UpdateOfferSupplementConfigurationPax>();
        services.AddSingleton<IDeleteOfferSupplementConfigurationPax, DeleteOfferSupplementConfigurationPax>();

        services.AddSingleton<ICreateOfferSupplementGroup, CreateOfferSupplementGroup>();
        services.AddSingleton<IUpdateOfferSupplementGroup, UpdateOfferSupplementGroup>();

        services.AddSingleton<ICreateOfferSupplementGroupRelation, CreateOfferSupplementGroupRelation>();
        services.AddSingleton<IDeleteOfferSupplementGroupRelation, DeleteOfferSupplementGroupRelation>();

        services.AddSingleton<ICreatePeriodPricing, CreatePeriodPricing>();
        services.AddSingleton<IUpdatePeriodPricing, UpdatePeriodPricing>();

        services.AddSingleton<ICreatePeriodPricingPax, CreatePeriodPricingPax>();
        services.AddSingleton<IUpdatePeriodPricingPax, UpdatePeriodPricingPax>();
        services.AddSingleton<IDeletePeriodPricingPax, DeletePeriodPricingPax>();

        services.AddSingleton<ICreateMeal, CreateMeal>();

        services.AddSingleton<ICreateRoom, CreateRoom>();

        services.AddSingleton<CreateStaticExtraTranslation, CreateStaticExtraTranslation>();
        services.AddSingleton<UpdateStaticExtraTranslation, UpdateStaticExtraTranslation>();
        services.AddSingleton<DeleteStaticExtraTranslation, DeleteStaticExtraTranslation>();

        services.AddSingleton<CreateStaticOfferSuplementTranslation>();
        services.AddSingleton<UpdateStaticOfferSupplementTranslation>();
        services.AddSingleton<DeleteStaticOfferSupplementTranslation>();

        services.AddSingleton<CreateStaticPaymentType>();
        services.AddSingleton<UpdateStaticPaymentType>();
        services.AddSingleton<DeleteStaticPaymentType>();

        services.AddSingleton<CreateStaticTax>();
        services.AddSingleton<UpdateStaticTax>();

        services.AddSingleton<CreateStaticHotelTax>();
        services.AddSingleton<DeleteStaticHotelTax>();

        services.AddScoped<PushHotel>();
        return services;
    }
}
