namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
public interface ICreateMinimumStay {
    Task<HttpResponseMessage> Execute(Conestmi conestmi);
}
