namespace Modsen.CodeCorrida.Web.Domain.Exceptions.UnprocessableContent;

public class UnprocessableContentException: ApplicationException
{
    public UnprocessableContentException()
        : base() { }

    public UnprocessableContentException(string message)
        : base(message) { }
}
