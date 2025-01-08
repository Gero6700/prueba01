namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public interface IUpdateCancellationPolicyLine {
    Task<HttpResponseMessage> Execute(Congasan congasan);
}
