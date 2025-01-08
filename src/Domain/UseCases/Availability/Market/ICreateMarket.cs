namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
public interface ICreateMarket {
    Task<HttpResponseMessage> Execute(Merca merca);
}
