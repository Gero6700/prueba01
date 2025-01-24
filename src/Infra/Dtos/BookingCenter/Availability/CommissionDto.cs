namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class CommissionDto {
    public required string Code { get; set; }
    public string? Name { get; set; }
    public decimal Value { get; set; }
}