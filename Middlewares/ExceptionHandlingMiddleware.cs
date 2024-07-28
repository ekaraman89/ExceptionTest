using System.Text.Json;
using ExceptionTest.Orchestration;

namespace ExceptionTest.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            _logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var orchestrator = context.RequestServices.GetRequiredService<ExceptionHandlerOrchestrator>();

        var details = orchestrator.HandleExceptionAsync(exception);

        // Set the problem details response
        context.Response.StatusCode = (int)details.Status;
        context.Response.ContentType = "application/problem+json";
        var problemDetails = JsonSerializer.Serialize(details);
        await context.Response.WriteAsync(problemDetails);

    }
}