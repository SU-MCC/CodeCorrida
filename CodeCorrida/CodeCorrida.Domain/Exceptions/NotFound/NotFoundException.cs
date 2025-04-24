namespace CodeCorrida.Domain.Exceptions.NotFound;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message)
        : base(message) { }
}
