using ExceptionTest.Base;
using ExceptionTest.Exceptions;
using ExceptionTest.ProblemDetails;

namespace ExceptionTest.Handlers;

public class BusinessExceptionHandler : ExceptionHandler<BusinessException>
{
    public override Microsoft.AspNetCore.Mvc.ProblemDetails HandleExceptionAsync(Exception exception) => new BusinessProblemDetails(exception.Message);
}