namespace CodeCorrida.Domain.Exceptions.MultiStatus;

public class MultiStatusException : ApplicationException
{
    public MultiStatusException(string message)
        : base(message) { }
}
