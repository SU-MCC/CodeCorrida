namespace Modsen.CodeCorrida.Web.Domain.Exceptions.BadRequest;

public class BadRequestException : ApplicationException
{
    public string[]? Arguments { get; }

    public BadRequestException()
        : base() { }

    public BadRequestException(string message)
        : base(message) { }

    public BadRequestException(string message, params string[] arguments)
        : this(message)
    {
        Arguments = arguments;
    }
}
