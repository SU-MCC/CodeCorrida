namespace Modsen.CodeCorrida.Web.Domain.Exceptions.Conflict;

public class ConflictException : ApplicationException
{
    public ConflictException()
    {
    }

    public ConflictException(string message)
        : base(message)
    {
    }

    public ConflictException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
