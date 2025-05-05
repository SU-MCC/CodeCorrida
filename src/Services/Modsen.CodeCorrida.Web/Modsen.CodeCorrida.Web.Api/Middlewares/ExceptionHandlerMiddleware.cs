using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Modsen.CodeCorrida.Web.Application.Helpers;
using Modsen.CodeCorrida.Web.Domain.Exceptions.BadRequest;
using Modsen.CodeCorrida.Web.Domain.Exceptions.Conflict;
using Modsen.CodeCorrida.Web.Domain.Exceptions.Forbidden;
using Modsen.CodeCorrida.Web.Domain.Exceptions.InvalidCredentials;
using Modsen.CodeCorrida.Web.Domain.Exceptions.LoopDetected;
using Modsen.CodeCorrida.Web.Domain.Exceptions.MultiStatus;
using Modsen.CodeCorrida.Web.Domain.Exceptions.NotFound;
using Modsen.CodeCorrida.Web.Domain.Exceptions.UnprocessableContent;

namespace Modsen.CodeCorrida.Web.Api.Middlewares;

public sealed class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var errorData = ExceptionHelper.HandleExceptionMessage(exception.Message);

        var exceptionResult = exception is BadRequestException { Arguments: not null } badRequestException
            ? JsonSerializer.Serialize(new
            {
                errorMessage = errorData.ErrorMessage,
                errorCode = errorData.ErrorCode,
                arguments = badRequestException.Arguments
            })
            : JsonSerializer.Serialize(new { errorMessage = errorData.ErrorMessage, errorCode = errorData.ErrorCode });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(exceptionResult);
    }

    private HttpStatusCode GetStatusCode(Exception exception) => exception switch
    {
        BadRequestException => HttpStatusCode.BadRequest,
        ValidationException => HttpStatusCode.BadRequest,
        InvalidCredentialsException => HttpStatusCode.Unauthorized,
        ForbiddenException => HttpStatusCode.Forbidden,
        NotFoundException => HttpStatusCode.NotFound,
        NotImplementedException => HttpStatusCode.NotImplemented,
        UnauthorizedAccessException => HttpStatusCode.Unauthorized,
        LoopDetectedException => HttpStatusCode.LoopDetected,
        ConflictException => HttpStatusCode.Conflict,
        UnprocessableContentException => HttpStatusCode.UnprocessableEntity,
        MultiStatusException => HttpStatusCode.MultiStatus,
        _ => HttpStatusCode.InternalServerError,
    };
}
