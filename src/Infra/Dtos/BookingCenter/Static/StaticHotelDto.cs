namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticHotelDto {
    public string? ChannelCode { get; set; }
    public required string Code { get; set; }
    public string? LocationCode { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public string? CodeType { get; set; }
    public string? Type { get; set; }
    public string? CurrencyIsoCode { get; set; }
    public string? Director { get; set; }
    public int? RoomsNumber { get; set; }
    public int? FloorsNumber { get; set; }
    public DateTime? OpeningDate { get; set; }
    public DateTime? ClosingDate { get; set; }
    public int? ConstructionYear { get; set; }
    public required bool HasSpecialTaxes { get; set; }
    public required StaticHotelChainDto HotelChain { get; set; }
    public required StaticHotelAddressDto HotelAddress { get; set; }
    public required StaticHotelTimeZoneDto HotelTimeZone { get; set; }
    public StaticHotelContactDto? HotelContact { get; set; }
    public required StaticHotelPaxAgesConfigurationDto HotelPaxAgesConfiguration { get; set; }
    public required IEnumerable<StaticHotelTranslationDto> HotelTranslations { get; set; }
    public IEnumerable<StaticHotelImageDto>? HotelImages { get; set; } //TODO: Nullable,ver con Jesús
    public IEnumerable<StaticHotelLanguageDto>? HotelLanguages { get; set; } //TODO: Nullable,ver con Jesús
    public IEnumerable<StaticHotelNoticeDto>? HotelNotices { get; set; }
    public required IEnumerable<StaticRoomDto> Rooms { get; set; }
    public required IEnumerable<StaticMealDto> Meals { get; set; }
    public IEnumerable<StaticServiceDto>? Services { get; set; }
    public IEnumerable<StaticSwimmingPoolDto>? SwimmingPools { get; set; }
    public IEnumerable<StaticSalonDto>? Salons { get; set; }
}

public class StaticHotelChainDto {
    public required string Code { get; set; }
    public string? CommercialName { get; set; }
    public string? Hash { get; set; }
    public required bool Active { get; set; }
}

public class StaticHotelAddressDto {
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? StateProvince { get; set; }
    public string? StateProvinceCode { get; set; }
    public string? City { get; set; }
    public string? CityCode { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? GooglePlaceId { get; set; }
}

public class StaticHotelTimeZoneDto {
    public required string GreenwichMeanTime { get; set; }
    public string? Description { get; set; }
}

public class StaticHotelContactDto {
    public string? ReferencePerson { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Web { get; set; }
}

public class StaticHotelPaxAgesConfigurationDto {
    public decimal? TeenagerMinAge { get; set; }
    public decimal? TeenagerMaxAge { get; set; }
    public decimal? ChildMinAge { get; set; }
    public decimal? ChildMaxAge { get; set; }
    public decimal? BabyMinAge { get; set; }
    public decimal? BabyMaxAge { get; set; }
}

public class StaticHotelTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public string? ShortDescription { get; set; }
    public string? LargeDescription { get; set; }
    public string? LocationDescription { get; set; }
}

public class StaticHotelImageDto : IImageDto {
    public int Order { get; set; }
    public string Url { get; set; } = string.Empty;
    public IEnumerable<StaticImageTranslationDto>? ImageTranslations { get; set; }
}

public class StaticHotelImageTranslationDto : IImageTranslationDto {
    public string LanguageIsoCode { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class StaticHotelLanguageDto {
    public required string LanguageIsoCode { get; set; }
    public required bool IsMain { get; set; }
}

public class StaticHotelNoticeDto {
    public required string LanguageIsoCode { get; set; }
    public required string Description { get; set; }
}

public class StaticRoomDto {
    public required string Code { get; set; }
    public int? RoomsNumber { get; set; }
    public decimal? Surface { get; set; }
    public IEnumerable<StaticRoomTranslationDto>? RoomTranslations { get; set; }
    public IEnumerable<StaticRoomImageDto>? RoomImages { get; set; }
    public StaticRoomPaxDto? RoomPax { get; set; } //TODO: Se ha quitado la lista, ver con Jesus
    public IEnumerable<StaticRoomBedDto>? RoomBeds { get; set; }
    public IEnumerable<StaticEquipmentDto>? Equipments { get; set; }
    public IEnumerable<StaticServiceDto>? Services { get; set; }
}

public class StaticRoomTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? LargeDescription { get; set; }
}

public class StaticRoomImageDto : IImageDto {
    public int Order { get; set; }
    public string Url { get; set; } = string.Empty;
    //public IEnumerable<StaticRoomImageTranslationDto>? ImageTranslations { get; set; }
    public IEnumerable<StaticImageTranslationDto>? ImageTranslations { get; set; }
}

public class StaticImageTranslationDto  {
    public required string LanguageIsoCode { get; set; } = string.Empty;
    public required string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}

//public class StaticRoomImageTranslationDto : IImageTranslationDto {
//    public string LanguageIsoCode { get; set; } = string.Empty;
//    public string Title { get; set; } = string.Empty;
//    public string? Description { get; set; }
//}

public class StaticRoomPaxDto {
    public decimal? MinWeight { get; set; }
    public decimal? MaxWeight { get; set; }
    public required int MinNumberAdults { get; set; }
    public required int MaxNumberAdults { get; set; }
    public decimal? MinNumberTeenagers { get; set; }
    public decimal? MaxNumberTeenagers { get; set; }
    public decimal? MinNumberChildren { get; set; }
    public decimal? MaxNumberChildren { get; set; }
    public decimal? MinNumberBabies { get; set; }
    public decimal? MaxNumberBabies { get; set; }
}

public class StaticRoomBedDto {
    public int? Width { get; set; }
    public int? Height { get; set; }
    public IEnumerable<StaticRoomBedTranslationDto>? RoomBedTranslations { get; set; }
}

public class StaticRoomBedTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Description { get; set; }
}

public class StaticEquipmentDto {
    public required string Name { get; set; }
    public IEnumerable<StaticEquipmentTranslationDto>? EquipmentTranslations { get; set; }
}

public class StaticEquipmentTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Description { get; set; }
}

public class StaticServiceDto {
    public required string Code { get; set; }
    public required StaticServiceCategoryDto ServiceCategory { get; set; }
    public IEnumerable<StaticServiceTranslationDto>? ServiceTranslations { get; set; }
}

public class StaticServiceCategoryDto {
    public required string Code { get; set; }
    public IEnumerable<StaticServiceCategoryTranslationDto>? ServiceCategoryTranslations { get; set; }
}

public class StaticServiceCategoryTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
}

public class StaticServiceTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class StaticMealDto {
    public required string Code { get; set; }
    public required IEnumerable<StaticMealTranslationDto> MealTranslations { get; set; }
}

public class StaticMealTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
}

public class StaticSwimmingPoolDto {
    public required string Code { get; set; }
    public required int PoolsNumber { get; set; }
    public required int Capacity { get; set; }
    public required decimal Surface { get; set; }
    public required bool IsOpen { get; set; }
    public required bool IsHeatedPool { get; set; }
    public required bool HasWaterSlides { get; set; }
    public IEnumerable<StaticSwimmingPoolTranslationDto>? SwimmingPoolTranslations { get; set; }
    public IEnumerable<StaticSwimmingPoolImageDto>? SwimmingPoolImages { get; set; }
}

public class StaticSwimmingPoolTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class StaticSwimmingPoolImageDto : IImageDto {
    public int Order { get; set; }
    public string Url { get; set; }
    public IEnumerable<StaticImageTranslationDto>? ImageTranslations { get; set; }
}

public class StaticSwimmingPoolImageTranslationDto {
    public required string LanguageIsoCode { get; set; } = string.Empty;
    public required string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class StaticSalonDto {
    public required string Code { get; set; }
    public required string Name { get; set; }
    public decimal? Surface { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public decimal? Large { get; set; }
    public int? BaseCapacity { get; set; }
    public int? BanquetCapacity { get; set; }
    public int? CocktailCapacity { get; set; }
    public int? ImperialCapacity { get; set; }
    public int? UCapacity { get; set; }
    public int? ClassroomCapacity { get; set; }
    public IEnumerable<StaticSalonTranslationDto>? SalonTranslations { get; set; }
    public IEnumerable<StaticSalonImageDto>? SalonImages { get; set; }
}

public class StaticSalonTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Description { get; set; }
}

public class StaticSalonImageDto {
    public required int Order { get; set; }
    public required string Url { get; set; }
    public IEnumerable<StaticSalonImageTranslationDto>? SalonImageTranslations { get; set; }
}

public class StaticSalonImageTranslationDto {
    public required string LanguageIsoCode { get; set; } = string.Empty;
    public required string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
