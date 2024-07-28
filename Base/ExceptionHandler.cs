using ExceptionTest.Interfaces;

namespace ExceptionTest.Base;

public abstract class ExceptionHandler<TException> : IExceptionHandler where TException : Exception
{
    public bool CanHandle(Exception exception) => exception is TException;

    public abstract Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception);
}