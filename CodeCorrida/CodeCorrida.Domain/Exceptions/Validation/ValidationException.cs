namespace CodeCorrida.Domain.Exceptions.Validation;

public sealed class ValidationException : ApplicationException
{
    public ValidationException(string message)
        : base(message) { }
}
