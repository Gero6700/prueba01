namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<Response> CreateCategory(Category category);
    Task<Response> UpdateCategory(Category category);
    Task<Response> DeleteCategory(string categoryCode);
}

