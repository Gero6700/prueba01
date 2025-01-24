namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class OfferSupplementGroupDto {
    public required string Code { get; set; }
    public required DateTime ApplyFrom { get; set; }
    public required DateTime ApplyTo { get; set; }
    public required IEnumerable<string> IntegrationContractCodes { get; set; }
}