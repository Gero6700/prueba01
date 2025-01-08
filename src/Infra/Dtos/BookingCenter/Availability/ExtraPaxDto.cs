namespace Availability.Synchronizer.Api.Dtos;

public class ExtraPaxDto {
    public int PaxOrder { get; init; }
    public required string PaxType { get; init; }
    public required string Scope { get; init; }
    public decimal? AgeFrom { get; init; }
    public decimal? AgeTo { get; init; }
    public decimal Amount { get; init; }
    public required string AmountType { get; init; }
}