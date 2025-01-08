namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
public interface IUpdateMarket {
    Task<HttpResponseMessage> Execute(Merca merca);
}
