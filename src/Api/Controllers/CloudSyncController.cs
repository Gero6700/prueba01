using Senator.As400.Cloud.Sync.Application.UseCases.Static;

namespace Senator.As400.Cloud.Sync.Api.Controllers; 

[ApiController]
[Route("[controller]")]
public class CloudSyncController : ControllerBase
{
    private readonly ILogger<CloudSyncController> logger;
    private readonly PushHotel pushHotel;

    public CloudSyncController(ILogger<CloudSyncController> logger, PushHotel pushHotel)
    {
        this.logger = logger;
        this.pushHotel = pushHotel;
    }

    [HttpPost]
    [Route("push-hotel/{hotelId}")]
    public async Task<IActionResult> PushHotel(int hotelId)
    {
        try {
            var pushHotelResult = await pushHotel.Execute(hotelId);
            if (pushHotelResult.IsSuccessStatusCode) {
                return Ok();
            }
            return StatusCode((int)pushHotelResult.StatusCode, "Hotel push error");
        }
        catch (Exception ex) {
            logger.LogError(ex, "Hotel push error");
            return StatusCode(500, "Hotel push error");
        }
    }
}
