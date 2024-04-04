namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<Response> CreateCategory(Category category);
}

