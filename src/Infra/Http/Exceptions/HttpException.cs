namespace Senator.As400.Cloud.Sync.Infrastructure.Http.Exceptions;

public class HttpException : Exception {
    public HttpResponseMessage Response { get; }

    public HttpException(HttpResponseMessage response, Exception? innerException)
        : base(response.ReasonPhrase, innerException) {
        Response = response;
    }
}