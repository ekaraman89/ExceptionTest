namespace ExceptionTest.ProblemDetails;

public class DefaultProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public DefaultProblemDetails(string detail)
    {
        Title = "Default Details";
        Detail = detail;
        Status = StatusCodes.Status409Conflict;
        Type = "https://example.com/probs/business";
        Instance = "";
    }
}