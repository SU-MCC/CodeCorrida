using CodeCorrida.Domain.Constants.ErrorCodes;

namespace CodeCorrida.Domain.Exceptions.InvalidCredentials;

public sealed class InvalidCredentialsException : ApplicationException
{
    public InvalidCredentialsException()
        : base(GeneralErrorCodes.InvalidCredentialsCode) { }

    public InvalidCredentialsException(string message)
        : base(message) { }
}

