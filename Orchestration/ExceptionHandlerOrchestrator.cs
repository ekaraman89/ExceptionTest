using ExceptionTest.Handlers;
using ExceptionTest.Interfaces;

namespace ExceptionTest.Orchestration;

public class ExceptionHandlerOrchestrator(IEnumerable<IExceptionHandler> handlers)
{
    public Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception)
    {
        var handler = handlers.FirstOrDefault(x => x.CanHandle(exception)) ?? new DefaultExceptionHandler();

        var details = handler.HandleExceptionAsync(exception);
        return details;
    }
}