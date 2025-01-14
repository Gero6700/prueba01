namespace Availability.Synchronizer.Api.Dtos;

public class MinimumStayDto {
    public required string Code { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int Days { get; set; }
    public bool StrictPeriod { get; set; }
    public required string IntegrationContractCode { get; set; }
    public string? RoomCode { get; set; }
    public string? MealCode { get; set; }
}