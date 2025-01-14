namespace Availability.Synchronizer.Api.Dtos;

public class OfferSupplementDto {
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required DateTime ApplyFrom { get; set; }
    public required DateTime ApplyTo { get; set; }
    public int? ApplyOrder { get; set; }
    public decimal? DepositAmount { get; set; }
    public string? DepositType { get; set; }
    public DateTime? DepositBeforeDate { get; set; }
    public decimal? ModificationCostsAmount { get; set; }
    public required IEnumerable<string> IntegrationContractCodes { get; set; }
    public required OfferSupplementConditionDto OfferSupplementCondition { get; set; }
    public required OfferSupplementConfigurationDto OfferSupplementConfiguration { get; set; }
}