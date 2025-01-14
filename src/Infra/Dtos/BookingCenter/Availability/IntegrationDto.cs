namespace Availability.Synchronizer.Api.Dtos;

public class IntegrationDto {
    public required string Code { get; set; }
    public string? CommercialName { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? ChannelManagerCode { get; set; }
    public string? ChannelCode { get; set; }
    public required bool Active { get; set; }
    public required string IntegrationClientTypeCode { get; set; }
}