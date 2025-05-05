namespace Modsen.CodeCorrida.Web.Domain.Exceptions.Registration;

public sealed class RegistrationException : ApplicationException
{
    public RegistrationException(string message)
        : base(message) { }
}
