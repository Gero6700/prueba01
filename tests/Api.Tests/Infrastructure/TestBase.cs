namespace Senator.As400.Cloud.Sync.Api.Tests.Infrastructure; 

public class TestBase {
    protected TestWebApplicationFactory? TestServer;
    
    [OneTimeSetUp]
    public void RunBeforeAnyTests() {
        TestServer = new TestWebApplicationFactory();
        // Create database (if exists)
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests() {
        TestServer?.Dispose();
    }

    [TearDown]
    public Task Down() {
        // Reset database (if exists)
        return Task.CompletedTask;
    }
}