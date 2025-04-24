using CodeCorrida.Domain.Constants.ErrorCodes;

namespace CodeCorrida.Application.Helpers;

public static class ExceptionHelper
{
    public static (string ErrorMessage, string ErrorCode) HandleExceptionMessage(string exception)
    {
        int.TryParse(exception, out int exceptionCode);

        if (exceptionCode == 0)
        {
            return (exception, string.Empty);
        }

        var exceptionMessage = HandleErrorCode(exceptionCode, exception);

        return (exceptionMessage, exceptionCode.ToString());
    }

    private static string HandleGeneralErrorCode(string exception) => exception switch
    {
        GeneralErrorCodes.InvalidCredentialsCode => "Invalid credentials",
        GeneralErrorCodes.CheckIdsExistenceFailedCode => "Failed to check existence of all given IDs",
        GeneralErrorCodes.ConcurrentTasksExecutionFailedCode => "Failed to execute all tasks concurrently",
        GeneralErrorCodes.EntityNotFoundByIdCode => "Entity not found for the provided Id",
        GeneralErrorCodes.BadClientHostCode => "Bad client host",
        GeneralErrorCodes.NotAllowedToViewRequestedAccessRequestsCode => "Not allowed to view requested access requests",
        GeneralErrorCodes.ManagerPredicateCannotBeNullCode => "Manager predicate cannot be null",
        _ => string.Empty
    };

    

    private static string HandleErrorCode(int exceptionCode, string errorValue)
    {
        if (IsInRange(exceptionCode, 20000, 20199))
        {
            return HandleGeneralErrorCode(errorValue);
        }

        return errorValue;
    }

    private static bool IsInRange(int value, int minValue, int maxValue)
    {
        return value >= minValue && value <= maxValue;
    }
}
