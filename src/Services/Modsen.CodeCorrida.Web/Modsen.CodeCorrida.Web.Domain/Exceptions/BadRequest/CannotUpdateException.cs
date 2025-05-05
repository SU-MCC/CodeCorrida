namespace Modsen.CodeCorrida.Web.Domain.Exceptions.BadRequest;

public sealed class CannotUpdateException : BadRequestException
{
    public CannotUpdateException(string message)
        : base(message) { }
}
