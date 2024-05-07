namespace OnlineBookstore.Exceptions;

public class DomainException : Exception
{
    public int HttpStatusCode { get; init; }
    public object? Error { get; init; }
    public string ErrorCode { get; init; } = default!;

    public DomainException(string message, int statusCode, object? error = null) : base(message)
    {
        HttpStatusCode = statusCode;
        Error = error;
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    { }

    protected DomainException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}