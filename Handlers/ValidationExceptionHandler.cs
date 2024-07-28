using ExceptionTest.Base;
using ExceptionTest.Exceptions;
using ExceptionTest.ProblemDetails;

namespace ExceptionTest.Handlers;

public class ValidationExceptionHandler : ExceptionHandler<ValidationException>
{
    public override Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception) => new ValidationProblemDetails(exception.Message);
}