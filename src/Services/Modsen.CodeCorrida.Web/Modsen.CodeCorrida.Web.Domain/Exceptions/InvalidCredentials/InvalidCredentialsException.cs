using Modsen.CodeCorrida.Web.Domain.Constants.ErrorCodes;

namespace Modsen.CodeCorrida.Web.Domain.Exceptions.InvalidCredentials;

public sealed class InvalidCredentialsException : ApplicationException
{
    public InvalidCredentialsException()
        : base(GeneralErrorCodes.InvalidCredentialsCode) { }

    public InvalidCredentialsException(string message)
        : base(message) { }
}

