namespace CodeCorrida.Domain.Exceptions.Forbidden;

public sealed class ForbiddenException : ApplicationException
{
    public ForbiddenException()
        : base() { }

    public ForbiddenException(string message)
        : base(message) { }
}
