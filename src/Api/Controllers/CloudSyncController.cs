namespace Senator.As400.Cloud.Sync.Api.Controllers; 

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/")]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> PushHotel(int hotelId)
    {
        var pushHotelResult = await pushHotel.Execute(hotelId);
        if (pushHotelResult.IsSuccess) {
                return Ok();
        }

        var problemsDetails = GetProblemDetails(pushHotelResult.Error, "Hotel push error");
        return new ObjectResult(problemsDetails) {
            StatusCode = problemsDetails.Status
        };
    }

    private ProblemDetails GetProblemDetails(Error error, string title) {
        var status = error.Code switch {
            "HotelService.HotelNotFound" => StatusCodes.Status404NotFound,
            "StaticSynchronizerApiClient.PushHotelError" => StatusCodes.Status502BadGateway,
            "GetHotelAsync.DatabaseFailure" => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
        return GetProblemDetails(status, error.Code, title, error.Message);
    }

    protected ProblemDetails GetProblemDetails(int status, string type, string title, string? detail) {
        return new ProblemDetails {
            Status = status,
            Type = type,
            Title = title,
            Detail = detail,
            Instance = $"{Request.Method} {Request.Path}"
        };
    }
}
