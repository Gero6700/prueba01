namespace Senator.As400.Cloud.Sync.Api.Tests.Infrastructure; 

public class TestWebApplicationFactory : WebApplicationFactory<Program> {
    protected override void ConfigureWebHost(IWebHostBuilder builder) {
        builder.UseEnvironment("Testing");
        base.ConfigureWebHost(builder);
    }
    
    protected override IHost CreateHost(IHostBuilder builder) {
        builder.ConfigureServices(services => {
            // Configure any mocks or similar
        });
        return base.CreateHost(builder);
    }
}