using ExceptionTest.Base;
using ExceptionTest.Exceptions;

namespace ExceptionTest.Handlers;

public class DefaultExceptionHandler : ExceptionHandler<DefaultException>
{
    public override Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception) => new();
}