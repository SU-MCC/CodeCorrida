using System.Text;

namespace CodeCorrida.Web.Middlewares;

public sealed class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggerMiddleware> _logger;

    public LoggerMiddleware(RequestDelegate next,
        ILogger<LoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        try
        {
            LogRequest(context);

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);

                var responseBodyText = await new StreamReader(context.Response.Body)
                    .ReadToEndAsync();

                context.Response.Body.Seek(0, SeekOrigin.Begin);

                LogResponse(context, responseBodyText);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured during the execution of endpoint " +
                $"{context.Request.Path} {context.Request.Method}");

            throw;
        }

        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private void LogRequest(HttpContext context)
    {
        var request = context.Request;

        var requestLog = new StringBuilder();
        requestLog.AppendLine("Incoming Request: ");
        requestLog.AppendLine($"Method: {request.Path} {request.Method}");

        _logger.LogInformation(requestLog.ToString());
    }

    private void LogResponse(HttpContext context, string responseBodyText)
    {
        var response = context.Response;

        var responseLog = new StringBuilder();
        responseLog.AppendLine("Outgoing Response:");
        responseLog.AppendLine($"Method: {context.Request.Path} {context.Request.Method}");
        responseLog.AppendLine($"Status code: {response.StatusCode}");

        if (!string.IsNullOrEmpty(responseBodyText) &&
            (response.StatusCode >= 400 && response.StatusCode < 600))
        {
            responseLog.AppendLine($"Error body: {responseBodyText}");

            _logger.LogError(responseLog.ToString());

            return;
        }

        _logger.LogInformation(responseLog.ToString());
    }
}
