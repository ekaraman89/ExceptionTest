namespace ExceptionTest.ProblemDetails;

public class ValidationProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public ValidationProblemDetails(string detail)
    {
        Title = "Validation Problem Details";
        Detail = detail;
        Status = StatusCodes.Status409Conflict;
        Type = "https://example.com/probs/business";
        Instance = "";
    }
}