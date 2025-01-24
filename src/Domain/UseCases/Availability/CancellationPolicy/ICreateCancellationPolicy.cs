namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public interface ICreateCancellationPolicy {
    Task<HttpResponseMessage> Execute(Congasan congasan);
}
