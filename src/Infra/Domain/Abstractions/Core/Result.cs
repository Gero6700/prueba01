namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Core;

public sealed record Error(string Code, string? Message = null) {
    public static readonly Error None = new(string.Empty);
    public static implicit operator Result(Error error) => Result.Failure(error);
}

public class Result {
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error) {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None) {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new(true, Error.None);
    
    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result {
    public T Value { get; set; }

    protected internal Result(T value, bool isSuccess, Error error) : base(isSuccess, error) {
        Value = value;
    }
	
    public static Result<T> Success(T value) => new(value, true, Error.None);
    
    public new static Result<T> Failure(Error error) => new(default!, false, error);
}

public static class ResultExtensions {
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<Error, T> onFailure) {
        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }
}