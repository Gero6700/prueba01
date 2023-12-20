namespace Senator.As400.Cloud.Sync.Api.Controllers; 

[ApiController]
[Route("[controller]")]
public class CloudSyncController : ControllerBase {
    private readonly ILogger<CloudSyncController> logger;

    public CloudSyncController(ILogger<CloudSyncController> logger) {
        this.logger = logger;
    }
}