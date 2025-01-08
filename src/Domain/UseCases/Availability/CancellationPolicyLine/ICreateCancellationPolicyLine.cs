namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public interface ICreateCancellationPolicyLine {
    Task<HttpResponseMessage> Execute(Congasan congasan);
}
