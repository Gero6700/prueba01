namespace Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

public class Response {
    public bool Success { get; set; }
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}
