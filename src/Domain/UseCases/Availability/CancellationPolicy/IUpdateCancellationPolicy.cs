namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public interface IUpdateCancellationPolicy {
    Task<HttpResponseMessage> Execute(Congasan congasan);
}
