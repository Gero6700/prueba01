namespace Availability.Synchronizer.Api.Dtos;

public class HotelSeasonsDto {
    public required string HotelCode { get; set; }
    public required IEnumerable<SeasonDto> Seasons { get; set; }
}

public class SeasonDto {
    public required DateTime OpeningDate { get; set; }
    public required DateTime ClosingDate { get; set; }
}