namespace CodeCorrida.Domain.Exceptions.Registration;

public sealed class RegistrationException : ApplicationException
{
    public RegistrationException(string message)
        : base(message) { }
}
