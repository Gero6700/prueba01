namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
public interface IUpdateMinimumStay {
    Task<HttpResponseMessage> Execute(Conestmi conestmi);
}
