namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
public interface IDeleteMinimumStay {
    Task<HttpResponseMessage> Execute(string Code);
}
