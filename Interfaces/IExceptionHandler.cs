namespace ExceptionTest.Interfaces;

public interface IExceptionHandler
{
    bool CanHandle(Exception exception);
    Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception);
}