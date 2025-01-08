namespace Availability.Synchronizer.Api.Dtos;

public class CommissionDto {
    public required string Code { get; set; }
    public string? Name { get; set; }
    public decimal Value { get; set; }
}